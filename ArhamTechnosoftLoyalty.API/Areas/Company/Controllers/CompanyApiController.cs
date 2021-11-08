using ArhamTechnosoftLoyalty.BAL.Repository;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private IUnitOfWork _unitOfWork;

        public CompanyApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("add-company")]
        public async Task<IActionResult> AddCompany(CompanyMaster CompanyMaster)
        {
            CustomResponse<bool> response = new CustomResponse<bool>();
            response = await _unitOfWork.companyMasterService.AddCompany(CompanyMaster);
            if (response.isSuccess == true)
            {
                return StatusCode(200, new
                {
                    code = 200,
                    message = "Company Saved Successfully.",
                    isSuccess = response.isSuccess,
                    data = response.data
                });
            }   
            return StatusCode(500, new
            {
                code = 500,
                message = response.message,
                data = response.data
            });
        }

        [HttpGet]
        [Route("get-company/{companyId?}")]
        public async Task<IActionResult> GetCompany(long? companyId)
        {
            CustomResponse<IList<CompanyMaster>> response = new CustomResponse<IList<CompanyMaster>>();
            response = await _unitOfWork.companyMasterService.GetCompanyMaster(companyId);
            if (response.isSuccess == true)
            {
                return StatusCode(200, new
                {
                    code = 200,
                    message = "Company Saved Successfully.",
                    isSuccess = response.isSuccess,
                    data = response.data
                });
            }
            return StatusCode(500, new
            {
                code = 500,
                message = response.message,
                data = response.data
            });
        }
    }
}
