using ArhamTechnosoftLoyalty.Models.Common;
using ArhamTechnosoftLoyalty.Models.Common.MasterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.MVC.Services
{
    public interface IGenericService
    {
        Task<ParentItems> GetMaster(List<string> Keys);
        Task<List<MasterDropdown>> GetMasterByParent(string Key, int parentId);
    }
}
