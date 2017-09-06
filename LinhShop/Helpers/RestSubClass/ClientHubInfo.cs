using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinhShop.Helpers.RestSubClass
{
    [Serializable]
    public class ClientHubInfo
    {
        public int PickHubID { get; set; }

        public string Address { get; set; }

        public string DistrictCode { get; set; }

        public string DistrictName { get; set; }

        public bool IsMain { get; set; }
    }
}