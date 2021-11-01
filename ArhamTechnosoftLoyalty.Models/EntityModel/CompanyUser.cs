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
        public virtual ApplicationUser applicationUser { get; set; }
    }
}
