using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Context
{
    public partial class Audit
    {
        public Guid Id { get; set; }
        public string UserAgent { get; set; }
        public string Ipaddress { get; set; }
        public string UrlRequired { get; set; }
    }
}
