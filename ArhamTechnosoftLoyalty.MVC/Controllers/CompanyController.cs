using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.MVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompanyController(ICompanyService companyService, UserManager<ApplicationUser> userManager)
        {
            _companyService = companyService;
            _userManager = userManager;
        }
        [Route("save-company")]
        public async Task<IActionResult> SaveCompany()
        {
            return View();
        }
        [HttpPost]
        [Route("save-company")]
        public async Task<IActionResult> SaveCompany(CompanyMaster companyMaster)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            companyMaster.CreatedBy = Guid.Parse(currentUser.Id);
            string retval = await _companyService.SaveCompany(companyMaster);
            if(retval == "SUCCESS")
            {
                return RedirectToAction("SaveCompany");
            }
            else
            {
                return RedirectToAction("SaveCompany");
            }
        }
    }
}
