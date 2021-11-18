using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.EntityModel;
using ArhamTechnosoftLoyalty.Models.ViewModel.Company;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Company
{
    public class CompanyMasterService : ICompanyMasterService
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        public CompanyMasterService(ArhamTechLoyaltyDbContext db)
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
                        entity.CreatedOn = entity.CompanyAddress.CreatedOn = entity.CompanyPhone.CreatedOn = entity.CompanyMail.CreatedOn = DateTime.UtcNow;
                        entity.CompanyMail.CreatedBy = entity.CompanyPhone.CreatedBy = entity.CompanyAddress.CreatedBy = (Guid)entity.CreatedBy;
                        entity.CompanyMail.IsActive = entity.IsActive = entity.CompanyPhone.IsActive = entity.CompanyAddress.IsActive = true;
                        var retval = _db.Add(entity);
                    }
                    else if (entity.CompanyId > 0)
                    {
                        entity.CompanyMail.UpdatedBy = entity.CompanyPhone.UpdatedBy = entity.CompanyAddress.UpdatedBy = entity.UpdatedBy;
                        entity.CompanyMail.UpdatedOn = entity.CompanyPhone.UpdatedOn = entity.CompanyAddress.UpdatedOn = DateTime.UtcNow;
                        _db.CompanyMaster.Attach(entity);
                        var entryCompany = _db.Entry(entity);
                        var entryAddress = _db.Entry(entity.CompanyAddress);
                        var entryPhone = _db.Entry(entity.CompanyPhone);
                        var entryEmail = _db.Entry(entity.CompanyMail);

                        entryCompany.Property(e => e.CompanyName).IsModified = true;
                        entryAddress.Property(e => e.AddressLine1).IsModified = true;
                        entryAddress.Property(e => e.AddressLine2).IsModified = true;
                        entryAddress.Property(e => e.CityId).IsModified = true;
                        entryAddress.Property(e => e.StateId).IsModified = true;
                        entryAddress.Property(e => e.CountryId).IsModified = true;
                        entryAddress.Property(e => e.UpdatedBy).IsModified = true;
                        entryAddress.Property(e => e.UpdatedOn).IsModified = true;

                        entryPhone.Property(e => e.PhoneNo).IsModified = true;
                        entryPhone.Property(e => e.UpdatedBy).IsModified = true;
                        entryPhone.Property(e => e.UpdatedOn).IsModified = true;

                        entryEmail.Property(e => e.EmailAddress).IsModified = true;
                        entryEmail.Property(e => e.UpdatedBy).IsModified = true;
                        entryEmail.Property(e => e.UpdatedOn).IsModified = true;
                    }

                    var result = _db.SaveChanges();
                    if (result > 0)
                    {
                        response.code = 200;
                        response.isSuccess = true;
                        response.data = true;
                        response.message = "Company saved successfully.";
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
        public Task<CustomResponse<List<CompanyListModel>>> GetCompanyList(long? companyId, string connStr)
        {
            CustomResponse<List<CompanyListModel>> response = new CustomResponse<List<CompanyListModel>>();
            response.isSuccess = false;
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("var_companyid", companyId);
                using (NpgsqlConnection sqlCon = new NpgsqlConnection(connStr))
                {
                    sqlCon.Open();
                    List<CompanyListModel> companyList = NpgHelper.QueryStoredProcPgSql<CompanyListModel>(sqlCon, "companymaster_get", dynamicParameters).ToList();
                    if(companyList != null)
                    {
                        response.message = "Company get successfuly.";
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
        public Task<CustomResponse<CompanyMaster>> GetCompanyMaster(long? companyId)
        {
            CustomResponse<CompanyMaster> response = new CustomResponse<CompanyMaster>();
            response.isSuccess = false;
            try
            {
                CompanyMaster companyMaster = new CompanyMaster();
                if (companyId != null && companyId > 0)
                {
                    companyMaster = _db.Set<CompanyMaster>()
                        .Include(i=>i.CompanyAddress)
                        .Include(i=>i.CompanyMail)
                        .Include(i=>i.CompanyPhone)
                        .FirstOrDefault(x=>x.CompanyId==companyId);

                    if (companyMaster != null)
                    {
                        response.code = 200;
                        response.isSuccess = true;
                        response.data = companyMaster;
                        response.message = "Company get successfully.";
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
        public Task<CustomResponse<bool>> DeleteCompany(long companyId)
        {
            CustomResponse<bool> response = new CustomResponse<bool>();
            response.isSuccess = false;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (companyId == 0)
                    {
                        response.isSuccess = false;
                    }
                    else if (companyId > 0)
                    {
                        var currentCompany = _db.CompanyMaster.Find(companyId);
                        currentCompany.IsActive = false;
                    }

                    var result = _db.SaveChanges();
                    if (result > 0)
                    {
                        response.code = 200;
                        response.isSuccess = true;
                        response.data = true;
                        response.message = "Company deleted successfully.";
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
    }
}
