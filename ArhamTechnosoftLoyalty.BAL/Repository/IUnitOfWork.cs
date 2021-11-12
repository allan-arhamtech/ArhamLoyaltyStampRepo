using ArhamTechnosoftLoyalty.BAL.Repository.Account;
using ArhamTechnosoftLoyalty.BAL.Repository.Branch;
using ArhamTechnosoftLoyalty.BAL.Repository.Company;
using ArhamTechnosoftLoyalty.BAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserService userService { get; }
        ICompanyMasterService companyMasterService { get; }
        IGenericService genericService { get; }
        IBranchService branchService { get; }
        void Save();
        
    }
}
