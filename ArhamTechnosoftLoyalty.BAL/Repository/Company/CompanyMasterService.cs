using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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

        public Task<CustomResponse<bool>> AddCompany(CompanyMaster entity)
        {
            CustomResponse<bool> response = new CustomResponse<bool>();
            response.isSuccess = false;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (entity.CompanyId == 0)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                    }
                    entity.UpdatedOn = DateTime.UtcNow;
                    var retval = _db.Add(entity);
                    var result = _db.SaveChanges();
                    if (result > 0)
                    {
                        response.isSuccess = true;
                        response.data.retValue = true;
                        transaction.Commit();
                    }
                }
                catch (NpgsqlException ex)
                {
                    transaction.Rollback();
                    _db.Dispose();
                    response.message = ex.Message;
                    response.isSuccess = false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _db.Dispose();
                    response.message = ex.Message;
                    response.isSuccess = false;
                }
            }
            return Task.FromResult(response);
        }

        public Task<CustomResponse<IList<CompanyMaster>>> GetCompanyMaster(long? companyId)
        {
            CustomResponse<IList<CompanyMaster>> response = new CustomResponse<IList<CompanyMaster>>();
            response.isSuccess = false;
            try
            {
                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("var_inputname", "HDFC");
                IList<object> getultimateparent = new List<object>();
                using (NpgsqlConnection sqlCon = new NpgsqlConnection("User ID=postgres;Password=DestServ@456;Host=3.7.23.160;Port=5432;Database=fsloader;Pooling=true;Timeout=300;CommandTimeout=300"))
                {
                    sqlCon.Open();
                    getultimateparent = NpgHelper.QueryStoredProcPgSql<object>(sqlCon, "getultimateparent", dynamicParameters1).ToList();
                }

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("var_companyid", companyId);
                IList<object> getultimateparent1 = new List<object>();
                using (NpgsqlConnection sqlCon = new NpgsqlConnection("User ID=postgres;Password=ArhamPg@123;Host=localhost;Port=5432;Database=LoyaltyStampDb;Pooling=true;Timeout=300;CommandTimeout=300"))
                {
                    sqlCon.Open();
                    IList<object> companyList = NpgHelper.QueryStoredProcPgSql<object>(sqlCon, "companymaster_get", dynamicParameters).ToList();
                }
            }
            catch (NpgsqlException ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.isSuccess = false;
            }
           
            return Task.FromResult(response);
        }
    }
}
