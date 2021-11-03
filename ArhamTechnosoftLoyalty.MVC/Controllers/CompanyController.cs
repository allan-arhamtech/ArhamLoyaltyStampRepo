using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [Route("save-company")]
        public async Task<IActionResult> SaveCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveCompany(CompanyMaster companyMaster)
        {
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
