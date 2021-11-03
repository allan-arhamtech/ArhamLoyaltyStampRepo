using ArhamTechnosoftLoyalty.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Services
{
    public interface ICompanyService
    {
        Task<string> SaveCompany(CompanyMaster companyMaster);
    }
}
