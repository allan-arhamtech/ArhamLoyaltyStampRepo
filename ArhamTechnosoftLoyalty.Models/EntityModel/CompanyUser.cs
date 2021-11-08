using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class CompanyUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual CompanyMaster CompanyMaster { get; set; }
        public virtual CompanyBranch CompanyBranch { get; set; }
    }
}
