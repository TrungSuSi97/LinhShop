using LinhNguyen.Domain;
using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using System.Web;
using System.IO;
using System.Data.Entity;
using LinhNguyen.Domain.Entities;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainContext _context;

        public ProductRepository(MainContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var existedProduct = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();

                if (existedProduct != null)
                {
                    _context.Products.Remove(existedProduct);
                    return _context.SaveChanges() > 0;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    
        public IQueryable<ProductModel> GetAllProduct()
        {
            return _context.Products.Where(x => x.IsDeleted == false)
                 .Select(x => new ProductModel
                 {
                     Cost = x.Cost,
                     CreateBy = x.CreateBy,
                     CreatedDate = x.CreatedDate,
                     ProductBy = x.ProductBy,
                     ProductId = x.ProductId,
                     ProductName = x.ProductName,
                     Size = x.Size,
                     Discount = x.Discount,
                     Description = x.Description,
                     AdditionalInformation = x.AdditionalInformation,
                     Modern = x.Modern,
                     Note = x.Note,
                     ImagePath1 = x.ImagePath1,
                     ImagePath2 = x.ImagePath2,
                     ImagePath3 = x.ImagePath3,
                     ImagePath4 = x.ImagePath4,
                     ImagePath5 = x.ImagePath5,
                     Code = x.Code,
                     IsNewCollection = x.IsNewCollection,
                     Quantity = x.Quantity,
                     NumLike = x.NumLike,
                     Color = x.Color,
                     FreeText = x.FreeText
                 });
        }

        public bool InsertOrUpdate(ProductModel model)
        {
            string rootPath = @"~/images/products/";
            var existedProduct = _context.Products.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
            if (existedProduct != null)
            {
                existedProduct.ProductName = model.ProductName;
                existedProduct.ProductBy = model.ProductBy;
                existedProduct.Cost = model.Cost;
                existedProduct.Discount = model.Discount;
                existedProduct.Catetory = model.Catetory;
                existedProduct.Size = model.Size;
                existedProduct.Description = model.Description;
                existedProduct.AdditionalInformation = model.AdditionalInformation;
                existedProduct.Note = existedProduct.Note;
                existedProduct.Modern = model.Modern;
                existedProduct.Code = model.Code;
                existedProduct.IsNewCollection = model.IsNewCollection;
                existedProduct.Quantity = model.Quantity;
                existedProduct.NumLike = model.NumLike;
                existedProduct.Color = model.Color;
                existedProduct.FreeText = model.FreeText;

                if (model.Image1 != null)
                {
                    // Delete existing image
                    var fullPath = HttpContext.Current.Server.MapPath(existedProduct.ImagePath1);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                    var pic = Path.GetFileName(model.Image1.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath(rootPath), pic);
                    // File is uploaded
                    model.Image1.SaveAs(path);

                    //get the file's name
                    var type = model.Image1.ContentType;
                    existedProduct.ImagePath1 = rootPath + model.Image1.FileName;
                }

                if (model.Image2 != null)
                {
                    // Delete existing image
                    var fullPath = HttpContext.Current.Server.MapPath(existedProduct.ImagePath2);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                    var pic = Path.GetFileName(model.Image2.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath(rootPath), pic);
                    // File is uploaded
                    model.Image2.SaveAs(path);

                    // get the file's name
                    var type = model.Image2.ContentType;
                    existedProduct.ImagePath2 = rootPath + model.Image3.FileName;
                }

                if (model.Image3 != null)
                {
                    //delete existing image
                    var fullPath = HttpContext.Current.Server.MapPath(existedProduct.ImagePath3);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    var pic = System.IO.Path.GetFileName(model.Image3.FileName);
                    var path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image3.SaveAs(path);

                    //get the file's name
                    var type = model.Image3.ContentType;
                    existedProduct.ImagePath3 = rootPath + model.Image3.FileName;
                }

                if (model.Image4 != null)
                {
                    //delete existing image
                    string fullPath = HttpContext.Current.Server.MapPath(existedProduct.ImagePath4);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    var pic = System.IO.Path.GetFileName(model.Image4.FileName);
                    var path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image4.SaveAs(path);

                    //get the file's name
                    string type = model.Image4.ContentType;
                    existedProduct.ImagePath4 = rootPath + model.Image4.FileName;
                }

                if (model.Image5 != null)
                {
                    //delete existing image
                    var fullPath = HttpContext.Current.Server.MapPath(existedProduct.ImagePath5);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    var pic = System.IO.Path.GetFileName(model.Image5.FileName);
                    var path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image5.SaveAs(path);

                    //get the file's name
                    var type = model.Image5.ContentType;
                    existedProduct.ImagePath5 = rootPath + model.Image5.FileName;
                }

                existedProduct.LastModifiedBy = model.LastModifiedBy;
                _context.Entry(existedProduct).State = EntityState.Modified;
            }
            else
            {
                var productEntity = new Product
                {
                    CreatedDate = DateTime.Now,
                    ProductName = model.ProductName,
                    ProductBy = model.ProductBy,
                    CreateBy = model.CreateBy,
                    Cost = model.Cost,
                    Catetory = model.Catetory,
                    Size = model.Size,
                    Discount = model.Discount,
                    Description = model.Description,
                    AdditionalInformation = model.AdditionalInformation,
                    Modern = model.Modern,
                    Note = model.Note,
                    IsNewCollection = model.IsNewCollection,
                    Quantity = model.Quantity,
                    NumLike = model.NumLike,
                    Color = model.Color,
                    Code = model.Code,
                    FreeText = model.FreeText
                };

                if (model.Image1 != null)
                {
                    string pic = System.IO.Path.GetFileName(model.Image1.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image1.SaveAs(path);

                    //get the file's name
                    string type = model.Image1.ContentType;

                    productEntity.ImagePath1 = rootPath + model.Image1.FileName;
                }

                if (model.Image2 != null)
                {
                    string pic = System.IO.Path.GetFileName(model.Image2.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image2.SaveAs(path);

                    //get the file's name
                    string type = model.Image2.ContentType;

                    productEntity.ImagePath2 = rootPath + model.Image2.FileName;
                }
                if (model.Image3 != null)
                {
                    string pic = System.IO.Path.GetFileName(model.Image3.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image3.SaveAs(path);

                    //get the file's name
                    string type = model.Image3.ContentType;

                    productEntity.ImagePath3 = rootPath + model.Image3.FileName;
                }
                if (model.Image4 != null)
                {
                    string pic = System.IO.Path.GetFileName(model.Image4.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image4.SaveAs(path);

                    //get the file's name
                    string type = model.Image4.ContentType;

                    productEntity.ImagePath4 = rootPath + model.Image4.FileName;
                }

                if (model.Image5 != null)
                {
                    string pic = System.IO.Path.GetFileName(model.Image5.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image5.SaveAs(path);

                    //get the file's name
                    string type = model.Image5.ContentType;

                    productEntity.ImagePath5 = rootPath + model.Image5.FileName;
                }

                _context.Products.Add(productEntity);
            }
            return _context.SaveChanges() > 0;
        }

        public IQueryable<ProductModel> ListProducts(int? type)
        {
            return _context.Products.Where(x => x.IsDeleted == false && ((int)x.Catetory == type))
                .Select(x => new ProductModel
                {
                    Catetory = x.Catetory,
                    Cost = x.Cost,
                    LastModifiedBy = x.LastModifiedBy,
                    CreateBy = x.CreateBy,
                    CreatedDate = x.CreatedDate,
                    ProductBy = x.ProductBy,
                    ProductId = x.ProductId,
                    Size = x.Size,
                    Discount = x.Discount,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    AdditionalInformation = x.AdditionalInformation,
                    Modern = x.Modern,
                    Note = x.Note,
                    ImagePath1 = x.ImagePath1,
                    ImagePath2 = x.ImagePath2,
                    ImagePath3 = x.ImagePath3,
                    ImagePath4 = x.ImagePath4,
                    ImagePath5 = x.ImagePath5,
                    IsNewCollection = x.IsNewCollection,
                    Quantity = x.Quantity,
                    NumLike = x.NumLike,
                    Color = x.Color,
                    Code = x.Code,
                    FreeText = x.FreeText
                });
        }

        public IQueryable<ProductModel> ListProductsByColor(int? color)
        {
            return _context.Products.Where(x => x.IsDeleted == false && ((int)x.Color == color))
                .Select(x => new ProductModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductBy = x.ProductBy,
                    CreateBy = x.CreateBy,
                    CreatedDate = x.CreatedDate,
                    Cost = x.Cost,
                    Code = x.Code,
                    Color = x.Color,
                    Modern = x.Modern,
                    Note = x.Note,
                    FreeText = x.FreeText,
                    NumLike = x.NumLike,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    AdditionalInformation = x.AdditionalInformation,
                    Discount = x.Discount,
                    LastModifiedBy = x.LastModifiedBy,
                    ImagePath1 = x.ImagePath1,
                    ImagePath2 = x.ImagePath2,
                    ImagePath3 = x.ImagePath3,
                    ImagePath4 = x.ImagePath4,
                    ImagePath5 = x.ImagePath5,
                    IsNewCollection = x.IsNewCollection
                });
        }

        public IQueryable<ProductModel> ListProductsBySize(int? size)
        {
            return _context.Products.Where(x => x.IsDeleted == false && ((int)x.Size == size))
                .Select(x => new ProductModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductBy = x.ProductBy,
                    CreateBy = x.CreateBy,
                    CreatedDate = x.CreatedDate,
                    Cost = x.Cost,
                    Code = x.Code,
                    Color = x.Color,
                    Modern = x.Modern,
                    Note = x.Note,
                    FreeText = x.FreeText,
                    NumLike = x.NumLike,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    AdditionalInformation = x.AdditionalInformation,
                    Discount = x.Discount,
                    LastModifiedBy = x.LastModifiedBy,
                    ImagePath1 = x.ImagePath1,
                    ImagePath2 = x.ImagePath2,
                    ImagePath3 = x.ImagePath3,
                    ImagePath4 = x.ImagePath4,
                    ImagePath5 = x.ImagePath5,
                    IsNewCollection = x.IsNewCollection
                });
        }
    }
}
