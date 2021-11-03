using ArhamTechnosoftLoyalty.Models.Account;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.Common.RolePermissionHelper;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Account;
using ArhamTechnosoftLoyalty.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Controllers
{
    [Route("Account")]
    [Route("")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private AppSettings _appSettings;
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public AccountController(SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
             IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [Route("Login")]
        [Route("")]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [Route("Login")]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Home/Index");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = loginModel.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("");
        }

        [Route("logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Route("role-list")]
        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [Route("add-role")]
        [HttpGet]
        public async Task<IActionResult> AddRole(string roleId, string roleName)
        {
            return View();
        }
        [Route("add-role")]
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("RoleList", "Account");
        }

        [Route("add-company-user")]
        [HttpGet]
        public async Task<IActionResult> AddCompanyUser(long applicationUserId)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View();
        }
        [Route("add-company-user")]
        [HttpPost]
        public async Task<IActionResult> AddCompanyUser(long applicationUserId, RegisterUser registerUser)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return RedirectToAction("");
        }
        
        [Route("get-role-permission/{roleId}")]
        [HttpGet]
        public async Task<ActionResult> GetRolePermission(string roleId)
        {
            PermissionViewModel model = new PermissionViewModel();
            List<RoleClaimsViewModel> allPermissions = new List<RoleClaimsViewModel>();
            allPermissions.GetPermissions(typeof(Permissions.UserManagement), roleId);
            allPermissions.GetPermissions(typeof(Permissions.Company), roleId);
            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermissions;
            return View(model);
        }

        [Route("update-role-permission")]
        [HttpPost]
        public async Task<IActionResult> UpdateRolePermission(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddPermissionClaim(role, claim.Value);
            }
            return RedirectToAction("GetRolePermission", new { roleId = model.RoleId });
        }

        [Route("register-company-user")]
        public async Task<IActionResult> RegisterCompanyUser()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return null;
        }
    }
}
