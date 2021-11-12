using ArhamTechnosoftLoyalty.API.Helper;
using ArhamTechnosoftLoyalty.BAL.Repository;
using ArhamTechnosoftLoyalty.BAL.Repository.Generic;
using ArhamTechnosoftLoyalty.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.API.Areas.Generic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        public GenericApiController(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        [HttpPost("get-key-value-list")]
        public async Task<IActionResult> GetDropDownList([FromBody] List<string> Keys)
        {
            IDictionary<string, object> ParentItems = new Dictionary<string, object>();
            List<MasterDropdown> response1 = new List<MasterDropdown>();
            foreach (string KeyName in Keys)
            {
                var response = await _unitOfWork.genericService.GetKeyValues(KeyName, _appSettings.DefaultConnection);
                ParentItems.Add(KeyName, response);
            }

            if (ParentItems != null && ParentItems.Count > 0)
            {
                return StatusCode(200, new
                {
                    code = "200",
                    status = "Records Found.",
                    data = new
                    {
                        ParentItems
                    }
                });
            }
            return StatusCode(400, new
            {
                code = "400",
                status = "No Records Found.",   
                data = new
                {
                    ParentItems
                }
            });
        }

        [HttpGet("get-key-value-by-parent/{key?}/{id?}")]
        public async Task<IActionResult> GetDropDownListByParent(string key, int id)
        {
            try
            {
                IDictionary<string, object> ParentItems = new Dictionary<string, object>();
                IList<MasterDropdown> dt = await _unitOfWork.genericService.GetKeyValuesByParent(id, key, _appSettings.DefaultConnection);
                ParentItems.Add(key, dt);

                if (ParentItems != null && ParentItems.Count > 0)
                {
                    return StatusCode(200, new
                    {
                        code = "200",
                        status = "Records Found.",
                        data = new
                        {
                            ParentItems
                        }
                    });
                }
                else
                {
                    return StatusCode(200, new
                    {
                        code = "200",
                        status = "No record found"

                    });
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    code = "500",
                    status = "Internal Server Error",
                    message = ex.Message
                });
            }
        }
    }
}
