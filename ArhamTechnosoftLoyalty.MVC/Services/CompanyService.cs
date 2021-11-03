using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.MVC.Helper;
using ArhamTechnosoftLoyalty.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Services
{
    public class CompanyService : ICompanyService
    {
        private LoyaltyAPI _loyaltyAPI;
        private AppSettings _appSettings;
        public CompanyService(IOptions<AppSettings> appSettings)
        {
            _loyaltyAPI = new LoyaltyAPI();
            _appSettings = appSettings.Value;
        }
        public async Task<string> SaveCompany(CompanyMaster companyMaster)
        {
            try
            {
                HttpClient client = _loyaltyAPI.Initial(_appSettings.ApiUrl.ToString());
                var responseTask = await client.PostAsJsonAsync("api/company/add-company", companyMaster);
                if (responseTask.IsSuccessStatusCode)
                {
                    return "SUCCESS";
                }
                else
                {
                    return responseTask.Content.ToString();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
