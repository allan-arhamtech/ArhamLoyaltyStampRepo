using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Company
{
    public interface ICompanyMasterService
    {
        Task<CustomResponse<bool>> AddCompany(CompanyMaster entity);
        Task<CustomResponse<List<CompanyListModel>>> GetCompanyList(long? companyId, string conn);
        Task<CustomResponse<CompanyMaster>> GetCompanyMaster(long? companyId);
    }
}
