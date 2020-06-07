using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.DTOs
{
    public class ResponseModel
    {
        public ResponseModel(bool success, object response = null, string message = null, int? errorCode = null)
        {
            Success = success;
            Data = response;
            ErrorCode = errorCode;
            Message = message;
        }

        public object Data { get; private set; }
        public bool Success { get; private set; }
        public int? ErrorCode { get; private set; }
        public string Message { get; private set; }
    }
}
