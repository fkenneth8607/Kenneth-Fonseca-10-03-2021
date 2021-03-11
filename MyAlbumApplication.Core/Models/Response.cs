using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAlbumApplication.Core.Models
{
    public class Response
    {
        public Response()
        {
            Status = false;
            Type = ResponseType.Error;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string Trace { get; set; }
        public ResponseType Type { get; set; }
    }

    public enum ResponseType
    {
        Success,
        Warning,
        Error
    }
}