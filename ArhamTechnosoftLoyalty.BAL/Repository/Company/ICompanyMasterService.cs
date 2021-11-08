using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Company
{
    public interface ICompanyMasterService : IRepository<CompanyMaster>
    {
        Task<CustomResponse<bool>> AddCompany(CompanyMaster entity);
        Task<CustomResponse<IList<CompanyMaster>>> GetCompanyMaster(long? companyId);
    }
}
