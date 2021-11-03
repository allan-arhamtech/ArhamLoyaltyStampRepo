﻿using ArhamTechnosoftLoyalty.BAL.Repository.Account;
using ArhamTechnosoftLoyalty.BAL.Repository.Company;
using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        public IApplicationUserService userService { get; private set; }
        public ICompanyMasterService companyMasterService { get; private set; }

        public UnitOfWork(ArhamTechLoyaltyDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            userService = new ApplicationUserService(_db, userManager);
            companyMasterService = new CompanyMasterService(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
