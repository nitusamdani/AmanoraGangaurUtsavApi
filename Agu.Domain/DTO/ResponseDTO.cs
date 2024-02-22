using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agu.Domain.DTO
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        public Object Data { get; set; } = string.Empty;
    }
}
