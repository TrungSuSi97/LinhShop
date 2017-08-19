using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface ICompanyInfoRepository
    {
        CompanyInfoModel GetCompanyInfo();
        bool InsertOrUpdate(CompanyInfoModel companyModel);
    }
}
