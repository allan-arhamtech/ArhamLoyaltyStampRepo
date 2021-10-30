using ArhamTechnosoftLoyalty.BAL.Utility;
using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Company
{
    public class CompanyMasterService : Repository<CompanyMaster>, ICompanyMasterService
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        
        public CompanyMasterService(ArhamTechLoyaltyDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Response> AddCompany(CompanyMaster entity)
        {
            Response response = new Response();
            response.IsSuccess = false;
            try
            {
                var retval = await _db.AddAsync(entity);
                var result = await _db.SaveChangesAsync();
                if (result == 1)
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                await _db.DisposeAsync();
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
