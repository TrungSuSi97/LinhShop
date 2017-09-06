using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class DistrictProvinceInfo
    {
        public int SupportType { get; set; }

        public int Type { get; set; }

        public string ProvinceName { get; set; }

        public string DistrictCode { get; set; }

        public string DistrictName { get; set; }
    }
}