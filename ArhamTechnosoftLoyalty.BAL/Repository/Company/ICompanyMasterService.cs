using ArhamTechnosoftLoyalty.BAL.Utility;
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
        Task<Response<bool>> AddCompany(CompanyMaster entity);
    }
}
