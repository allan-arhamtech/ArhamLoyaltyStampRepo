using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Branch;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Branch
{
    public class BranchService : IBranchService
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        public BranchService(ArhamTechLoyaltyDbContext db)
        {
            _db = db;
        }
        public Task<CustomResponse<bool>> AddBranch(CompanyBranch entity)
        {
            CustomResponse<bool> response = new CustomResponse<bool>();
            response.isSuccess = false;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (entity.BranchId == 0)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                        entity.IsActive = true;
                        var retval = _db.Add(entity);
                    }
                    else if (entity.BranchId > 0)
                    {
                        entity.UpdatedOn = DateTime.UtcNow;
                        var updateRetVal = _db.Update(entity);
                    }

                    var result = _db.SaveChanges();
                    if (result > 0)
                    {
                        response.code = 200;
                        response.isSuccess = true;
                        response.data = true;
                        response.message = "Branch add successfully.";
                        transaction.Commit();
                    }
                }
                catch (NpgsqlException ex)
                {
                    response.code = 500;
                    response.isSuccess = false;
                    response.data = false;
                    response.message = ex.Message;
                    transaction.Rollback();
                    _db.Dispose();
                    response.message = ex.Message;
                    response.isSuccess = false;
                }
                catch (Exception ex)
                {
                    response.code = 500;
                    response.isSuccess = false;
                    response.data = false;
                    response.message = ex.Message;
                    transaction.Rollback();
                    _db.Dispose();
                    response.message = ex.Message;
                    response.isSuccess = false;
                }
            }
            return Task.FromResult(response);
        }
        public Task<CustomResponse<List<BranchListModel>>> GetBranchList(long? branchId, long? companyId, string connStr)
        {
            CustomResponse<List<BranchListModel>> response = new CustomResponse<List<BranchListModel>>();
            response.isSuccess = false;
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("var_companyid", companyId);
                dynamicParameters.Add("var_branchid", branchId);
                using (NpgsqlConnection sqlCon = new NpgsqlConnection(connStr))
                {
                    sqlCon.Open();
                    List<BranchListModel> companyList = NpgHelper.QueryStoredProcPgSql<BranchListModel>(sqlCon, "companybranch_get", dynamicParameters).ToList();
                    if (companyList != null)
                    {
                        response.message = "Branch get successfuly.";
                        response.isSuccess = true;
                        response.data = companyList;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
                response.data = null;
                response.message = ex.Message;
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.isSuccess = false;
                response.data = null;
                response.message = ex.Message;
            }

            return Task.FromResult(response);
        }
        public Task<CustomResponse<CompanyBranch>> GetBranch(long? branchId)
        {
            CustomResponse<CompanyBranch> response = new CustomResponse<CompanyBranch>();
            response.isSuccess = false;
            try
            {
                CompanyBranch branch = new CompanyBranch();
                if (branchId != null && branchId > 0)
                {
                    branch = _db.Set<CompanyBranch>()
                        .Include(i => i.BranchAddress)
                        .Include(i => i.BranchMail)
                        .Include(i => i.BranchPhone)
                        .FirstOrDefault(x => x.BranchId == branchId);

                    if (branch != null)
                    {
                        response.code = 200;
                        response.isSuccess = true;
                        response.data = branch;
                        response.message = "Branch get successfully.";
                    }
                }

            }
            catch (NpgsqlException ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
                response.data = null;
                response.message = ex.Message;
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.isSuccess = false;
                response.data = null;
                response.message = ex.Message;
            }

            return Task.FromResult(response);
        }   
    }
}
