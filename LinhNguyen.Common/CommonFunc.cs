using LinhNguyen.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Common
{
    public class CommonFunc
    {
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static CategoryType GetCategoryTypeById(int id)
        {
            switch(id)
            {
                case 1:
                    return CategoryType.Dam;
                case 2:
                    return CategoryType.Chan_Vay;
                case 3:
                    return CategoryType.Quan;
                case 4:
                    return CategoryType.Ao;
                case 5:
                    return CategoryType.Bo_Suu_Tap;
                case 6:
                    return CategoryType.Jumpsuits;
                default:
                    return CategoryType.Dam;
            }
        }

        public static List<CbbModel> ExpirationMonth()
        {
            var cbbs = new List<CbbModel>();
            cbbs.Add(new CbbModel { Id = 1, Name = "Jan (01)" });
            cbbs.Add(new CbbModel { Id = 2, Name = "Feb (02)" });
            cbbs.Add(new CbbModel { Id = 3, Name = "Mar (03)" });
            cbbs.Add(new CbbModel { Id = 4, Name = "Apr (04)" });
            cbbs.Add(new CbbModel { Id = 5, Name = "May (05)" });
            cbbs.Add(new CbbModel { Id = 6, Name = "June (06)" });
            cbbs.Add(new CbbModel { Id = 7, Name = "July (07)" });
            cbbs.Add(new CbbModel { Id = 8, Name = "Aug (08)" });
            cbbs.Add(new CbbModel { Id = 9, Name = "Sep (09)" });
            cbbs.Add(new CbbModel { Id = 10, Name = "Oct (10)" });
            cbbs.Add(new CbbModel { Id = 11, Name = "Nov (11)" });
            cbbs.Add(new CbbModel { Id = 12, Name = "Dec (12)" });
            return cbbs;
        }
        public static List<CbbModel> ExpirationYear()
        {
            var cbbs = new List<CbbModel>();
            cbbs.Add(new CbbModel { Id = 2013, Name = "2013" });
            cbbs.Add(new CbbModel { Id = 2014, Name = "2014" });
            cbbs.Add(new CbbModel { Id = 2015, Name = "2015" });
            cbbs.Add(new CbbModel { Id = 2016, Name = "2016" });
            cbbs.Add(new CbbModel { Id = 2017, Name = "2017" });
            cbbs.Add(new CbbModel { Id = 2018, Name = "2018" });
            cbbs.Add(new CbbModel { Id = 2019, Name = "2019" });
            cbbs.Add(new CbbModel { Id = 2020, Name = "2020" });
            cbbs.Add(new CbbModel { Id = 2021, Name = "2021" });
            cbbs.Add(new CbbModel { Id = 2022, Name = "2022" });
            cbbs.Add(new CbbModel { Id = 2023, Name = "2023" });
            cbbs.Add(new CbbModel { Id = 2024, Name = "2024" });

            return cbbs;
        }
    }
}
