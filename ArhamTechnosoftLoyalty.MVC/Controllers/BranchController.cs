using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.Common.MasterModel;
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

        public BranchController(IOptions<AppSettings> appSettings, IGenericService genericService, UserManager<ApplicationUser> userManager)
        {
            _loyaltyAPI = new LoyaltyAPI();
            _appSettings = appSettings.Value;
            _genericService = genericService;
            _userManager = userManager; 
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
            if (branchId != null && branchId > 0)
            {
                HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());

                //get branch
                var responseBranch = await client.GetAsync("branch/get-branch-master/" + branchId);
                if (responseBranch.IsSuccessStatusCode)
                {
                    var resultBranch = responseBranch.Content.ReadAsStringAsync().Result;
                    CustomResponse<CompanyBranch> companymaster = JsonConvert.DeserializeObject<CustomResponse<CompanyBranch>>(resultBranch);
                    branchViewModel.companyBranch = companymaster.data;
                }
                //get state master
                var responseState = await client.GetAsync("GenericApi/get-key-value-by-parent/" + "state" + "/" + branchViewModel.companyBranch.BranchAddress.CountryId);
                if (responseState.IsSuccessStatusCode)
                {
                    var resultState = responseState.Content.ReadAsStringAsync().Result;
                    CustomResponseData<ParentItems> stateMaster = JsonConvert.DeserializeObject<CustomResponseData<ParentItems>>(resultState);
                    branchViewModel.masters.state = stateMaster.data.parentItems.state;
                }
                //get city master
                var responseCity = await client.GetAsync("GenericApi/get-key-value-by-parent/" + "city" + "/" + branchViewModel.companyBranch.BranchAddress.StateId);
                if (responseCity.IsSuccessStatusCode)
                {
                    var resultCity = responseCity.Content.ReadAsStringAsync().Result;
                    CustomResponseData<ParentItems> cityMaster = JsonConvert.DeserializeObject<CustomResponseData<ParentItems>>(resultCity);
                    branchViewModel.masters.city = cityMaster.data.parentItems.city;
                }
            }

            return View(branchViewModel);
        }
        [HttpPost]
        [Route("save-branch/{branchId?}")]
        public async Task<IActionResult> SaveBranch(long? branchId, CompanyBranch companyBranch)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (branchId != null || branchId > 0)
            {
                companyBranch.BranchId = (long)branchId;
                companyBranch.UpdatedBy = Guid.Parse(currentUser.Id);
            }
            else
            {
                companyBranch.CreatedBy = Guid.Parse(currentUser.Id);
            }
            
            HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());
            var responseTask = await client.PostAsJsonAsync("branch/add-branch", companyBranch);
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                CustomResponse<bool> Listing = JsonConvert.DeserializeObject<CustomResponse<bool>>(result);
                return RedirectToAction("GetBranches");
            }
            else
            {
                return RedirectToAction("SaveBranch");
            }
        }

        [HttpGet]
        [Route("get-branches")]
        public async Task<IActionResult> GetBranches()
        {
            HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());
            var responseTask = await client.GetAsync("branch/get-branch-list");
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                CustomResponse<List<BranchListModel>> Listing = JsonConvert.DeserializeObject<CustomResponse<List<BranchListModel>>>(result);
                return View(Listing.data);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Route("branch-view/{branchId}")]
        public async Task<IActionResult> GetBranchListById(long branchId)
        {
            HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());
            var responseTask = await client.GetAsync("branch/get-branch-list");
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                CustomResponse<List<BranchListModel>> Listing = JsonConvert.DeserializeObject<CustomResponse<List<BranchListModel>>>(result);
                return View(Listing.data.FirstOrDefault());
            }
            else
            {
                return View();
            }
        }
    }
}
