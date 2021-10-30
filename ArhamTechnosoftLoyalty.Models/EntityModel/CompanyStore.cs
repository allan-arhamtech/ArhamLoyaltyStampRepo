using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class CompanyStore
    {
        [Key]
        public long StoreId { get; set; }
        public string StoreName { get; set; }
        public long CompanyId { get; set; }
        public CompanyMaster Company { get; set; }
    }
}
