using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface IResourceRepository
    {
        IQueryable<ResourceModel> GetListResource();
        bool InsertOrUpdate(ResourceModel resModel);
        bool Delete(int id);
    }
}
