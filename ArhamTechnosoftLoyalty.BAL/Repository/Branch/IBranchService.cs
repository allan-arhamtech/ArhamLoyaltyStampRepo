using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Branch
{
    public interface IBranchService
    {
        Task<CustomResponse<bool>> AddBranch(CompanyBranch entity);
        Task<CustomResponse<List<BranchListModel>>> GetBranchList(long? branchId, long? companyId, string connStr);
        Task<CustomResponse<CompanyBranch>> GetBranch(long? branchId);
    }
}
