using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.Common.MasterModel;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Company;
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
        [Route("save-company/{companyId?}")]
        public async Task<IActionResult> SaveCompany(long? companyId)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            List<string> Keys = new List<string>()
            {
                "country"
            };
            companyViewModel.masters = await _companyService.GetMaster(Keys);
            if (companyId != null && companyId > 0)
            {
                companyViewModel.companyMaster = await _companyService.GetCompanyMaster(companyId);
                companyViewModel.masters.state = await _companyService.GetMasterByParent("state", companyViewModel.companyMaster.CompanyAddress.CountryId);
                companyViewModel.masters.city = await _companyService.GetMasterByParent("city", companyViewModel.companyMaster.CompanyAddress.StateId);
            }
            
            return View(companyViewModel);
        }
        [HttpPost]
        [Route("save-company/{companyId?}")]
        public async Task<IActionResult> SaveCompany(long? companyId, CompanyMaster companyMaster)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (companyId != null || companyId > 0)
            {
                companyMaster.CompanyId = (long)companyId;
                companyMaster.UpdatedBy = Guid.Parse(currentUser.Id);
            }
            else
            {
                companyMaster.CreatedBy = Guid.Parse(currentUser.Id);
            }
            string retval = await _companyService.SaveCompany(companyMaster);
            if(retval == "SUCCESS")
            {
                return RedirectToAction("GetCompanies");
            }
            else
            {
                return RedirectToAction("SaveCompany");
            }
        }

        [HttpGet]
        [Route("get-companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companyList = await _companyService.GetCompanyList(null);
            return View(companyList);
        }

        [HttpGet]
        [Route("company-view/{companyId}")]
        public async Task<IActionResult> GetCompanyListById(long companyId)
        {
            var companyList = await _companyService.GetCompanyList(companyId);
            return View(companyList.FirstOrDefault());
        }
    }
}
