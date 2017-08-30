using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using LinhNguyen.Domain;
using System.Data.Entity;
using LinhNguyen.Domain.Entities;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly MainContext _context;

        public ResourceRepository(MainContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var existedResource = _context.Resources.Where(x => x.Id == id).FirstOrDefault();
            if (existedResource != null)
            {
                _context.Resources.Remove(existedResource);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public IQueryable<ResourceModel> GetListResource()
        {
            return _context.Resources.Where(x => x.IsDeleted == false)
                .Select(x => new ResourceModel
                {
                    Id = x.Id,
                    CreateBy = x.CreateBy,
                    CreatedDate = x.CreatedDate,
                    LastModifiedBy = x.LastModifiedBy,
                    Culture = x.Culture,
                    Name = x.Name,
                    Value = x.Value
                });
        }

        public bool InsertOrUpdate(ResourceModel resModel)
        {
            var existedResource = _context.Resources.Where(x => x.Id == resModel.Id).FirstOrDefault();
            if (existedResource != null)
            {
                existedResource.Name = resModel.Name;
                existedResource.Value = resModel.Value;
                _context.Entry(existedResource).State = EntityState.Modified;
            }
            else
            {
                var resourceEntity = new Resource
                {
                    CreateBy = resModel.CreateBy,
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = resModel.LastModifiedBy,
                    Culture = resModel.Culture,
                    Name = resModel.Name,
                    Value = resModel.Value
                };

                _context.Resources.Add(existedResource);
            }

            return _context.SaveChanges() > 0;
        }
    }
}
