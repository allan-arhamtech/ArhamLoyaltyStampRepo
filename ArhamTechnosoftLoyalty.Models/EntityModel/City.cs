using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public int state_id { get; set; }
        public string state_code { get; set; }
        public int country_id { get; set; }
        public string country_code { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
