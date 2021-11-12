using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.ViewModel.Branch
{
    public class BranchListModel
    {
        public long BranchId { get; set; }
        public long CompanyId { get; set; }
        public string BranchName { get; set; }
        public string CompanyName { get; set; }
        public string BranchEmail { get; set; }
        public string BranchPhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
