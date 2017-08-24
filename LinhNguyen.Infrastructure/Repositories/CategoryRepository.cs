using LinhNguyen.Domain;
using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using System.IO;
using System.Data.Entity;
using LinhNguyen.Domain.Entities;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainContext _context;

        public CategoryRepository(MainContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var currentCategory = _context.Categories.Where(x => x.Id == id).FirstOrDefault();                 
                if (currentCategory != null)
                {
                    _context.Categories.Remove(currentCategory);
                    return _context.SaveChanges() > 0;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<CategoryModel> GetListCategory()
        {
            try
            {
                return _context.Categories.Where(x => x.IsDeleted == false)
                    .Select(x => new CategoryModel
                    {
                        Id = x.Id,
                        CategoryName = x.CategoryName,
                        Type = x.Type,
                        CreatedDate = x.CreatedDate,
                        CreateBy = x.CreateBy,
                        ImagePic = x.ImagePic,
                        ImageType = x.ImageType
                    });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool InsertOrUpdate(CategoryModel categoryModel)
        {
            try
            {
                var existedCategory = _context.Categories
                    .Where(x => x.Id == categoryModel.Id && x.CategoryName == categoryModel.CategoryName).SingleOrDefault();

                if (existedCategory != null)
                {
                    existedCategory.CategoryName = categoryModel.CategoryName;
                    existedCategory.Type = categoryModel.Type;
                    existedCategory.LastModifiedBy = categoryModel.LastModifiedBy;

                    if (categoryModel.Image != null)
                    {
                        //get the file's name
                        var type = categoryModel.Image.ContentType;
                        //get the bytes from the content stream of the file
                        var thePictureAsBytes = new byte[categoryModel.Image.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(categoryModel.Image.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(categoryModel.Image.ContentLength);
                        }
                        existedCategory.ImagePic = thePictureAsBytes;
                        existedCategory.ImageType = type;
                    }

                    _context.Entry(existedCategory).State = EntityState.Modified;
                }
                else
                {
                    //get the file's name
                    string type = categoryModel.Image.ContentType;
                    //get the bytes from the content stream of the file
                    byte[] thePictureAsBytes = new byte[categoryModel.Image.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(categoryModel.Image.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(categoryModel.Image.ContentLength);
                    }

                    var categoryEnity = new Category
                    {
                        CreatedDate = DateTime.Now,
                        CreateBy = categoryModel.CreateBy,
                        Type = categoryModel.Type,
                        CategoryName = categoryModel.CategoryName,
                        ImagePic = categoryModel.ImagePic,
                        ImageType = type
                    };

                    _context.Categories.Add(categoryEnity);
                }

                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsCategoryNameExist(string model)
        {
            try
            {
                var existingCategoryName = _context.Categories.Where(x => x.CategoryName.ToLowerInvariant().Equals(model.ToLower())).FirstOrDefault() != null;

                return existingCategoryName;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
