using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class CompanyBranch
    {
        [Key]
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Company { get; set; }
    }
}
