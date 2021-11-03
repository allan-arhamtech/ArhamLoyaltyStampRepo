using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Utility
{
    public class Response<T>
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public bool IsSuccess { get; set; }
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T retValue { get; set; }
    }
}
