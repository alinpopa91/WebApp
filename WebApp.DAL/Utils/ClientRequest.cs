using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.DAL.Utils
{
    public class ClientRequest
    {
        public string UserAgent { get; set; }
        public string IP { get; set; }
        public string Url { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
