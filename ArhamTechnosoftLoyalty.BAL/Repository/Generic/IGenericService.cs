using ArhamTechnosoftLoyalty.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository.Generic
{
    public interface IGenericService
    {
        Task<List<MasterDropdown>> GetKeyValues(string key, string connStr);
        Task<List<MasterDropdown>> GetKeyValuesByParent(int parentId, string key, string connStr);
    }
}
