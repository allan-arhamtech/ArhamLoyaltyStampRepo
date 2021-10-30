using ArhamTechnosoftLoyalty.BAL.Repository;
using ArhamTechnosoftLoyalty.BAL.Utility;
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
            //string token = HttpContext.GetToken();
            //string result = _appSettings.AuthenticateUser(token);
            if (true == true)
            {
                try
                {
                    Response response = await _unitOfWork.companyMasterService.AddCompany(CompanyMaster);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        code = 500,
                        status = "Internal Server Error",
                        message = ex.Message
                    });
                }

                return StatusCode(404, new
                {
                    code = 404,
                    status = "not found",
                    message = "No Records Found"
                });
            }
        }
    }
}
