using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ServicesFeeInfo
    {
        public double Weight { get; set; }
        public string FromDistrictCode { get; set; }
        public string FromDistrictName { get; set; }
        public string ToDistrictCode { get; set; }
        public string ToDistrictName { get; set; }
        public int ServiceID { get; set; }
        public double ServiceFee { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}