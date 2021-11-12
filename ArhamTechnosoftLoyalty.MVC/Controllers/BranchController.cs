using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Branch;
using ArhamTechnosoftLoyalty.MVC.Helper;
using ArhamTechnosoftLoyalty.MVC.Models;
using ArhamTechnosoftLoyalty.MVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Controllers
{
    public class BranchController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private LoyaltyAPI _loyaltyAPI;
        private AppSettings _appSettings;
        private IGenericService _genericService;

        public BranchController(IOptions<AppSettings> appSettings, IGenericService genericService)
        {
            _loyaltyAPI = new LoyaltyAPI();
            _appSettings = appSettings.Value;
            _genericService = genericService;
        }
        [Route("save-branch/{branchId?}")]
        public async Task<IActionResult> SaveBranch(long? branchId)
        {
            BranchViewModel branchViewModel = new BranchViewModel();
            List<string> Keys = new List<string>()
            {
                "country","companymaster"
            };
            branchViewModel.masters = await _genericService.GetMaster(Keys);
            //if (branchId != null && branchId > 0)
            //{
            //    companyViewModel.companyMaster = await _companyService.GetCompanyMaster(companyId);
            //    companyViewModel.masters.state = await _companyService.GetMasterByParent("state", companyViewModel.companyMaster.CompanyAddress.CountryId);
            //    companyViewModel.masters.city = await _companyService.GetMasterByParent("city", companyViewModel.companyMaster.CompanyAddress.StateId);
            //}

            return View(branchViewModel);
        }
        [HttpPost]
        [Route("save-branch/{companyId?}")]
        public async Task<IActionResult> SaveBranch(long? branchId, CompanyBranch companyBranch)
        {
            if (branchId != null || branchId > 0)
            {
                companyBranch.BranchId = (long)branchId;
            }
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            companyBranch.CreatedBy = Guid.Parse(currentUser.Id);
            HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());
            var responseTask = await client.PostAsJsonAsync("branch/add-branch", companyBranch);
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                CustomResponse<bool> Listing = JsonConvert.DeserializeObject<CustomResponse<bool>>(result);
                return RedirectToAction("save-branch");
            }
            else
            {
                return RedirectToAction("save-branch");
            }
        }
    }
}
