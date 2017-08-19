using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface INewsRepository
    {
        IQueryable<NewsModel> GetListNews();
        bool InsertOrUpdate(NewsModel newsModel);
        bool Delete(int id);
    }
}
