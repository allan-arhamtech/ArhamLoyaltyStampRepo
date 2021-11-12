using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.Common.MasterModel
{
    public class ParentItems
    {
        public List<MasterDropdown> country { get; set; }
        public List<MasterDropdown> state { get; set; }
        public List<MasterDropdown> city { get; set; }
        public List<MasterDropdown> companymaster { get; set; }
    }
}
