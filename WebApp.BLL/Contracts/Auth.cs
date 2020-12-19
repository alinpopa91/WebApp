using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.BLL.Contracts
{
    public class AuthRQ
    {
        public int AccountID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class AuthRS
    {
        public bool Success { get; set; }
        public string token { get; set; }
    }
}
