using ArhamTechnosoftLoyalty.BAL.Repository;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.API.Areas.UserManagement.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public UserApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("add-user")]
        public async Task<IActionResult> AddUser(RegisterUser registerUser)
        {
            //string token = HttpContext.GetToken();
            //string result = _appSettings.AuthenticateUser(token);
            if (true == true)
            {
                try
                {
                    _unitOfWork.userService.CompanyUserRegister(registerUser);
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
