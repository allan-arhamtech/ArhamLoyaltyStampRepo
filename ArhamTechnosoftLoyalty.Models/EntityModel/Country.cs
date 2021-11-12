using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso2 { get; set; }
        public string phone_code { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
