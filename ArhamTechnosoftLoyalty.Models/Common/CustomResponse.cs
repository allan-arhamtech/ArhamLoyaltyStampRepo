using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.Common
{
    public class CustomResponse<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public T data { get; set; }
    }

    public class CustomResponseData<T>
    {
        public CustomResponseData()
        {
            data = new Data<T>();
        }
        public int code { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public Data<T> data { get; set; }
    }
    public class Data<T>
    {
        public T parentItems { get; set; }
    }
}
