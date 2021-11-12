using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.Common.MasterModel;
using ArhamTechnosoftLoyalty.MVC.Helper;
using ArhamTechnosoftLoyalty.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Controllers
{
    [Route("GenericMvc")]
    public class GenericMvcController : Controller
    {
        private LoyaltyAPI _loyaltyAPI;
        private AppSettings _appSettings;
        public GenericMvcController(IOptions<AppSettings> appSettings)
        {
            _loyaltyAPI = new LoyaltyAPI();
            _appSettings = appSettings.Value;
        }
        [Route("GetChildDropdown")]
        public async Task<JsonResult> GetChildDropdown([FromQuery] int id, string master)
        {
            HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());
            var responseTask = await client.GetAsync("GenericApi/get-key-value-by-parent/" + master + "/" + id);
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                var Dropdownmaster = JsonConvert.DeserializeObject<CustomResponseData<ParentItems>>(result);
                if (Dropdownmaster.data.parentItems.state != null)
                {
                    return Json(Dropdownmaster.data.parentItems.state);
                }
                else if (Dropdownmaster.data.parentItems.city != null)
                {
                    return Json(Dropdownmaster.data.parentItems.city);
                }

            }
            return null;
        }
    }
}
