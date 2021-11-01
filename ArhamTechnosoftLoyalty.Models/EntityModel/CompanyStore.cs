using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class CompanyStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StoreId { get; set; }
        public string StoreName { get; set; }
        public long CompanyId { get; set; }
        public virtual CompanyMaster Company { get; set; }
    }
}
