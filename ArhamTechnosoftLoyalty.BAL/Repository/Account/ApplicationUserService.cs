using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Account
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(ArhamTechLoyaltyDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<bool> CompanyUserRegister(RegisterUser registerUser)
        {
            using (_db.Database.BeginTransactionAsync())
            {
                try
                {
                    //var applicationUser = companyUser.applicationUser;
                    //await _db.Database.CommitTransactionAsync();
                    //var user = companyUser.applicationUser;
                    //if (_userManager.Users.All(u => u.Id != user.Id &&  u.Email != user.Email ))
                    //{
                    //    await _userManager.CreateAsync(applicationUser, "jfjlkjs");
                    //}
                    return true;
                }
                catch
                {
                    await _db.Database.RollbackTransactionAsync();
                    Console.WriteLine("Error occurred.");
                    return false;
                }
            }
        }

    }
}
