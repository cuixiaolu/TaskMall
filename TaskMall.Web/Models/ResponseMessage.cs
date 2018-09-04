using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskMall.Web
{
    public class ResponseMessage
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }

        public static ResponseMessage GetResponseMessage(object data, int status, string message)
        {
            return new ResponseMessage { Data = data, Status = status, Message = message };
        }

        public static ResponseMessage GetSucess(object data)
        {
            return GetResponseMessage(data, 0, "");
        }

        public static ResponseMessage GetError(string message, int status = 1)
        {
            return GetResponseMessage(null, status, message);
        }
    }
}