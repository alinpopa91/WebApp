using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WebApp.BLL.Contracts
{
    [DataContract]
    public class SearchRQ
    {
        [DataMember(Name = "Name", IsRequired = false)]
        public string Name { get; set; }

        [DataMember(Name = "Category", IsRequired = false)]
        public int Category { get; set; }
        [DataMember(Name = "PriceMin", IsRequired = false)]
        public decimal PriceMin { get; set; }

        [DataMember(Name = "PriceMax", IsRequired = false)]
        public decimal PriceMax { get; set; }

        [DataMember(Name = "Size", IsRequired = false)]
        public string Size { get; set; }

        [DataMember(Name = "Original", IsRequired = false)]
        public string Original { get; set; }

        [DataMember(Name = "Signed", IsRequired = false)]
        public bool? Signed { get; set; }

        [DataMember(Name = "Page", IsRequired = true)]
        public int Page { get; set; }
    }
}
