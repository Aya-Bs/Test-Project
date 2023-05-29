using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requests
{
    public class ResponseObject
    {
        public bool isValid { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
