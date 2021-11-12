using ArhamTechnosoftLoyalty.Models.Common.MasterModel;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.ViewModel.Branch
{
    public class BranchViewModel
    {
        public ParentItems masters { get; set; } = new ParentItems();
        public CompanyBranch companyBranch { get; set; } = new CompanyBranch();
    }
}
