using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.DTOs
{
    public class ResponseModel
    {
        public ResponseModel() { }
        public ResponseModel(object response = null, int? errorCode = null, string message = null)
        {
            Data = response;
            ErrorCode = errorCode;
            Message = message;
        }

        public object Data { get; set; }
        public int? ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
