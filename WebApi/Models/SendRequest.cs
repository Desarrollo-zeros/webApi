using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class SendRequest
    {
        public string Message { set; get; }
        public string Number { set; get; }

        public short Type { set; get; }
    }
}
