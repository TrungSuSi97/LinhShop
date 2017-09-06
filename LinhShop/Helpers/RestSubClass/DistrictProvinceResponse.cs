using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class DistrictProvinceResponse
    {
        public List<DistrictProvinceInfo> Data { get; set; }
    }
}