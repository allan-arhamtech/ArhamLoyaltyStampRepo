using ArhamTechnosoftLoyalty.API.Helper;
using ArhamTechnosoftLoyalty.BAL.Repository;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.API.Controllers.Branch
{
    [Route("api/branch")]
    [ApiController]
    public class BranchApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public BranchApiController(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("add-branch")]
        public async Task<IActionResult> AddBranch(CompanyBranch companyBranch)
        {
            CustomResponse<bool> response = new CustomResponse<bool>();
            if (!ModelState.IsValid)
            {
                response.code = 422;
                response.message = "Unprocessable entity.";
                response.isSuccess = false;
                return StatusCode(422, response);
            }
            response = await _unitOfWork.branchService.AddBranch(companyBranch);
            if (response.isSuccess == true)
            {
                return StatusCode(200, response);
            }
            return StatusCode(500, response);
        }

        [HttpGet]
        [Route("get-branch-list/{branchId?}/{companyId?}")]
        public async Task<IActionResult> GetBranchList(long? branchId, long? companyId)
        {
            CustomResponse<List<BranchListModel>> response = new CustomResponse<List<BranchListModel>>();
            response = await _unitOfWork.branchService.GetBranchList(branchId, companyId, _appSettings.DefaultConnection);
            if (response.isSuccess == true)
            {
                return StatusCode(200, response);
            }
            return StatusCode(500, response);
        }

        [HttpGet]
        [Route("get-branch-master/{branchId?}")]
        public async Task<IActionResult> GetBranchMaster(long? branchId)
        {
            CustomResponse<CompanyBranch> response = new CustomResponse<CompanyBranch>();
            response = await _unitOfWork.branchService.GetBranch(branchId);
            if (response.isSuccess == true)
            {
                return StatusCode(200, response);
            }
            return StatusCode(500, response);
        }
    }
}
