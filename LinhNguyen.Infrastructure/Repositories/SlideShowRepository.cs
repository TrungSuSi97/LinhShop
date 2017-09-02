using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using LinhNguyen.Domain;
using System.Web;
using System.IO;
using System.Data.Entity;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class SlideShowRepository : ISlideShowRepository
    {
        private readonly MainContext _context;

        public SlideShowRepository(MainContext context)
        {
            _context = context;
        }

        public IQueryable<MainSlideShowModel> GetListSlideShow()
        {
            return _context.SlideShow.Where(x => x.Id > 0)
                .Select(x => new MainSlideShowModel
                {
                    Id = x.Id,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Title3 = x.Title3,
                    Title4 = x.Title4,
                    ImagePath1 = x.ImagePath1,
                    ImagePath2 = x.ImagePath2,
                    ImagePath3 = x.ImagePath3,
                    ImagePath4 = x.ImagePath4
                });
        }

        public bool InsertOrUpdate(MainSlideShowModel model)
        {
            var rootPath = @"~/images/slideshow/";
            var existed = _context.SlideShow.Where(x => x.Id == model.Id).FirstOrDefault();
            if (existed != null)
            {
                existed.Title1 = model.Title1;
                existed.Title2 = model.Title2;
                existed.Title3 = model.Title3;
                existed.Title4 = model.Title4;

                if (model.Image1 != null)
                {
                    //Delete existing image
                    var fullPath = HttpContext.Current.Server.MapPath(existed.ImagePath1);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }

                    var pic = Path.GetFileName(model.Image1.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath(rootPath), pic);

                    //File is uploadded
                    model.Image1.SaveAs(path);
                    //Get the file name
                    var type = model.Image1.ContentType;
                    existed.ImagePath1 = rootPath + model.Image1.FileName;
                }

                if (model.Image2 != null)
                {
                    //delete existing image
                    string fullPath = HttpContext.Current.Server.MapPath(existed.ImagePath2);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    string pic = System.IO.Path.GetFileName(model.Image2.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image2.SaveAs(path);

                    //get the file's name
                    string type = model.Image2.ContentType;
                    existed.ImagePath2 = rootPath + model.Image2.FileName;
                }

                if (model.Image3 != null)
                {
                    //delete existing image
                    string fullPath = HttpContext.Current.Server.MapPath(existed.ImagePath3);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    string pic = System.IO.Path.GetFileName(model.Image3.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image3.SaveAs(path);

                    //get the file's name
                    string type = model.Image3.ContentType;
                    existed.ImagePath3 = rootPath + model.Image3.FileName;
                }

                if (model.Image4 != null)
                {
                    //delete existing image
                    string fullPath = HttpContext.Current.Server.MapPath(existed.ImagePath4);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    string pic = System.IO.Path.GetFileName(model.Image4.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath(rootPath), pic);
                    // file is uploaded
                    model.Image4.SaveAs(path);

                    //get the file's name
                    string type = model.Image4.ContentType;
                    existed.ImagePath4 = rootPath + model.Image4.FileName;
                }

                _context.Entry(existed).State = EntityState.Modified;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
