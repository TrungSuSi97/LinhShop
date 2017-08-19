using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface ICategoryRepository
    {
        IQueryable<CategoryModel> GetListCategory();
        bool InsertOrUpdate(CategoryModel categoryModel);
        bool Delete(int id);
        bool IsCategoryNameExist(string model);
    }
}
