using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Models
{
    public class StatusCodeModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorStatusCode { get; set; }
        public string Message { get; internal set; }
    }
}
