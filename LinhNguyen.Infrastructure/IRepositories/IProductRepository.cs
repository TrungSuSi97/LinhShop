using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface IProductRepository
    {
        IQueryable<ProductModel> GetAllProduct();
        bool InsertOrUpdate(ProductModel product);
        bool Delete(int id);
        IQueryable<ProductModel> ListProducts(int? type);
        IQueryable<ProductModel> ListProductsByColor(int? color);
        IQueryable<ProductModel> ListProductsBySize(int? size);
    }
}
