using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.Common.MasterModel;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Services
{
    public interface ICompanyService
    {
        Task<string> SaveCompany(CompanyMaster companyMaster);
        Task<List<CompanyListModel>> GetCompanyList(long? companyId);
        Task<ParentItems> GetMaster(List<string> Keys);
        Task<CompanyMaster> GetCompanyMaster(long? companyId);
        Task<List<MasterDropdown>> GetMasterByParent(string Key, int parentId);
    }
}
