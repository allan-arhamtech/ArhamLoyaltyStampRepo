using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Account
{
    public class ApplicationUserService : Repository<ApplicationUser>, IApplicationUserService
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        public ApplicationUserService(ArhamTechLoyaltyDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
