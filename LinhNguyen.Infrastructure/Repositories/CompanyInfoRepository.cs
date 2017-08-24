using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using LinhNguyen.Domain;
using System.IO;
using System.Web;
using System.Data.Entity;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private MainContext _context;
        public CompanyInfoRepository(MainContext context)
        {
            _context = context;
        }
        public CompanyInfoModel GetCompanyInfo()
        {
            return _context.CompanyInfo.Where(x => x.Id > 0)
                 .Select(x => new CompanyInfoModel
                 {
                     Id = x.Id,
                     Logan = x.Logan,
                     Address = x.Address,
                     Email = x.Email,
                     HotLine = x.HotLine,
                     PathImageLogo = x.PathImageLogo,
                     Phone = x.Phone,
                     PathImageIdentity = x.PathImageIdentity,
                     PathImagePaymentMethod = x.PathImagePaymentMethod,
                     PathImageTransfer = x.PathImageTransfer,
                     Title = x.Title,
                     DateToChangeProduct = x.DateToChangeProduct,
                     FreeToDelivery = x.FreeToDelivery,
                     Copyright = x.Copyright,
                     PercentForPoint = x.PercentForPoint,
                     NumberPointForPercent = x.NumberPointForPercent,
                     PickHubCode = x.PickHubCode,
                     PickHubText = x.PickHubText,
                     UsdExchange = x.UsdExchange
                 }).FirstOrDefault();
        }

        public bool InsertOrUpdate(CompanyInfoModel companyModel)
        {
            var existed = _context.CompanyInfo.Where(x => x.Id == companyModel.Id).FirstOrDefault();
            var path = "~/images/company-info/";
            if (existed != null)
            {
                existed.Address = companyModel.Address;
                existed.Phone = companyModel.Phone;
                existed.HotLine = companyModel.HotLine;
                existed.Logan = companyModel.Logan;
                existed.Email = companyModel.Email;
                existed.Title = companyModel.Title;
                existed.DateToChangeProduct = companyModel.DateToChangeProduct;
                existed.FreeToDelivery = companyModel.FreeToDelivery;
                existed.PercentForPoint = companyModel.PercentForPoint;
                existed.NumberPointForPercent = companyModel.NumberPointForPercent;
                existed.PickHubCode = companyModel.PickHubCode;
                existed.PickHubText = companyModel.PickHubText;
                existed.UsdExchange = companyModel.UsdExchange;
                if (companyModel.ImageLogo != null)
                {
                    // delete existing image 
                    if (File.Exists(HttpContext.Current.Server.MapPath(existed.PathImageLogo)))
                    {
                        File.Delete(HttpContext.Current.Server.MapPath(existed.PathImageLogo));
                    }

                    companyModel.ImageLogo.SaveAs(HttpContext.Current.Server.MapPath(path +  companyModel.ImageLogo.FileName));
                    existed.PathImageLogo = path + companyModel.ImageLogo.FileName; 
                }

                if (companyModel.ImageIdentity != null)
                {
                    // delete existing image 
                    if (File.Exists(existed.PathImageIdentity))
                    {
                        File.Delete(existed.PathImageIdentity);
                    }

                    companyModel.ImageIdentity.SaveAs(HttpContext.Current.Server.MapPath(path + companyModel.ImageIdentity.FileName));
                    existed.PathImageIdentity = path + companyModel.ImageIdentity.FileName;
                }

                if (companyModel.ImagePaymentMethod != null)
                {
                    // delete existing image 
                    if (System.IO.File.Exists(existed.PathImagePaymentMethod))
                    {
                        System.IO.File.Delete(existed.PathImagePaymentMethod);
                    }

                    companyModel.ImagePaymentMethod.SaveAs(HttpContext.Current.Server.MapPath(path + companyModel.ImagePaymentMethod.FileName));
                    existed.PathImagePaymentMethod = path + companyModel.ImagePaymentMethod.FileName;
                }

                if (companyModel.ImageTransfer != null)
                {
                    // delete existing image 
                    if (System.IO.File.Exists(existed.PathImageTransfer))
                    {
                        System.IO.File.Delete(existed.PathImageTransfer);
                    }

                    companyModel.ImageTransfer.SaveAs(HttpContext.Current.Server.MapPath(path + companyModel.ImageTransfer.FileName));
                    existed.PathImageTransfer = path + companyModel.ImageTransfer.FileName;
                }

                _context.Entry(existed).State = EntityState.Modified;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
