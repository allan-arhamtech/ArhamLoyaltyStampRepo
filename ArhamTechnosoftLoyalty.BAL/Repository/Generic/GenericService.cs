using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.Common;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Generic
{
    public class GenericService : IGenericService
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        public GenericService(ArhamTechLoyaltyDbContext db)
        {
            _db = db;
        }

        public Task<List<MasterDropdown>> GetKeyValues(string key, string connStr)
        {
            List<MasterDropdown> response = new List<MasterDropdown>();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("var_key", key);
                using (NpgsqlConnection sqlCon = new NpgsqlConnection(connStr))
                {
                    sqlCon.Open();
                    response = NpgHelper.QueryStoredProcPgSql<MasterDropdown>(sqlCon, "keyvalue_get", dynamicParameters).ToList();
                }
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
            catch (Exception ex)
            {

                return null;
            }

            return Task.FromResult(response);
        }

        public Task<List<MasterDropdown>> GetKeyValuesByParent(int parentId, string key, string connStr)
        {
            List<MasterDropdown> response = new List<MasterDropdown>();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("var_parentid", parentId);
                dynamicParameters.Add("var_key", key);
                using (NpgsqlConnection sqlCon = new NpgsqlConnection(connStr))
                {
                    sqlCon.Open();
                    response = NpgHelper.QueryStoredProcPgSql<MasterDropdown>(sqlCon, "keyvalue_getbyparent", dynamicParameters).ToList();
                }
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
            catch (Exception ex)
            {

                return null;
            }

            return Task.FromResult(response);
        }
    }
}
