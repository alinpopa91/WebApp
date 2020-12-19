using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WebApp.DAL.Context;

namespace WebApp.BLL.Contracts
{
    public class SearchRS
    {
        public List<ArtDirectory> ArtDirectory { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
