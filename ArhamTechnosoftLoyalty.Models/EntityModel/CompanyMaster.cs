using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public partial class CompanyMaster
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public virtual Email CompanyMail { get; set; }
        public virtual Phone CompanyPhone { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        //[ForeignKey("CompanyAddressId")]
        //public long CompanyAddressId { get; set; }
        public virtual Address CompanyAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
