using ArhamTechnosoftLoyalty.API.Helper;
using ArhamTechnosoftLoyalty.BAL.Repository;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.API.Areas.Company.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public CompanyApiController(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("add-company")]
        public async Task<IActionResult> AddCompany(CompanyMaster CompanyMaster)
        {
            CustomResponse<bool> response = new CustomResponse<bool>();
            if (!ModelState.IsValid)
            {
                response.code = 422;
                response.message = "Unprocessable entity.";
                response.isSuccess = false;
                return StatusCode(422,response);
            }
            response = await _unitOfWork.companyMasterService.AddCompany(CompanyMaster);
            if (response.isSuccess == true)
            {
                return StatusCode(200, response);
            }   
            return StatusCode(500, response);
        }

        [HttpGet]
        [Route("get-company-list/{companyId?}")]
        public async Task<IActionResult> GetCompanyList(long? companyId)
        {
            CustomResponse<List<CompanyListModel>> response = new CustomResponse<List<CompanyListModel>>();
            response = await _unitOfWork.companyMasterService.GetCompanyList(companyId, _appSettings.DefaultConnection);
            if (response.isSuccess == true)
            {
                return StatusCode(200, response);
            }
            return StatusCode(500, response);
        }

        [HttpGet]
        [Route("get-company-master/{companyId?}")]
        public async Task<IActionResult> GetCompanyMaster(long? companyId)
        {
            CustomResponse<CompanyMaster> response = new CustomResponse<CompanyMaster>();
            response = await _unitOfWork.companyMasterService.GetCompanyMaster(companyId);
            if (response.isSuccess == true)
            {
                return StatusCode(200, response);
            }
            return StatusCode(500, response);
        }
    }
}
