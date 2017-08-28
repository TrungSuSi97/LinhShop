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
using LinhNguyen.Domain.Entities;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly MainContext _context;

        public NewsRepository(MainContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var existedNews = _context.News.Where(x => x.Id == id).FirstOrDefault();

            if (existedNews != null)
            {
                _context.News.Remove(existedNews);
                return _context.SaveChanges() > 0;
            }

            return false;
        }

        public IQueryable<NewsModel> GetListNews()
        {
            return _context.News.Where(x => x.IsDeleted == false)
                 .Select(x => new NewsModel
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Content = x.Content,
                     CreateBy = x.CreateBy,
                     CreatedDate = x.CreatedDate,
                     ImagePath = x.ImagePath,
                     LastModifiedBy = x.LastModifiedBy,
                     Paragraph = x.Paragraph
                 });
        }

        public bool InsertOrUpdate(NewsModel newsModel)
        {
            var existedNews = _context.News.Where(x => x.Id == newsModel.Id).FirstOrDefault();
            var path = "~/images/news/";
            if (existedNews != null)
            {
                existedNews.Title = newsModel.Title;
                existedNews.CreateBy = newsModel.CreateBy;
                existedNews.LastModifiedBy = newsModel.LastModifiedBy;
                existedNews.Paragraph = newsModel.Paragraph;
                existedNews.Content = newsModel.Content;
                if (newsModel.Image != null)
                {
                    // delete existing image 
                    if (File.Exists(HttpContext.Current.Server.MapPath(existedNews.ImagePath)))
                    {
                        File.Delete(HttpContext.Current.Server.MapPath(existedNews.ImagePath));
                    }

                    newsModel.Image.SaveAs(HttpContext.Current.Server.MapPath(path + newsModel.Image.FileName));
                    existedNews.ImagePath = path + newsModel.Image.FileName;
                }
                _context.Entry(existedNews).State = EntityState.Modified;
            }
            else
            {
                var newsEntity = new News
                {
                    Title = newsModel.Title,
                    Content = newsModel.Content,
                    CreatedDate = newsModel.CreatedDate,
                    CreateBy = newsModel.CreateBy,
                    ImagePath = path + newsModel.Image.FileName,
                    LastModifiedBy = newsModel.LastModifiedBy,
                    Paragraph = newsModel.Paragraph
                };

                if (newsModel.Image != null)
                {
                    // delete existing image 
                    if (File.Exists(HttpContext.Current.Server.MapPath(path + newsModel.Image.FileName)))
                    {
                        newsEntity.ImagePath = path + newsModel.Image.FileName;
                    }
                    else
                    {
                        newsModel.Image.SaveAs(HttpContext.Current.Server.MapPath(path + newsModel.Image.FileName));
                        newsEntity.ImagePath = path + newsModel.Image.FileName;
                    }
                }

                _context.News.Add(newsEntity);
            }

            return _context.SaveChanges() > 0;
        }
    }
}
