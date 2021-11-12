using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class CompanyBranch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public virtual Email BranchMail { get; set; }
        public virtual Phone BranchPhone { get; set; }
        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyMaster Company { get; set; }
        public virtual Address BranchAddress { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
