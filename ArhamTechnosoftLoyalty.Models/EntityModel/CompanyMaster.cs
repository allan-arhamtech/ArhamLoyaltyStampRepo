﻿using System;
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
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
