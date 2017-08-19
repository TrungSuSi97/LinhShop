using LinhNguyen.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Infrastructure.Models;
using LinhNguyen.Domain;
using LinhNguyen.Domain.Entities;
using LinhNguyen.Common;
using System.IO;
using System.Web;
using System.Data.Entity;

namespace LinhNguyen.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = true;
        }

        public bool AddContact(ContactUsModel contactModel)
        {
            try
            {
                var contact = new ContactUs
                {
                    CreatedDate = DateTime.Today,
                    Email = contactModel.Email,
                    FullName = contactModel.FullName,
                    Object = contactModel.Subject,
                    Phone = contactModel.Phone
                };

                _context.ContactUs.Add(contact);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var existingUser = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                _context.Users.Remove(existingUser);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }

        public UserModel DoLogin(LoginModel model)
        {
            try
            {
                model.Password = CommonFunc.CalculateMD5Hash(model.Password);
                var user = _context.Users.Where(x => (x.Email == model.Email || x.UserName == model.UserName
                || x.UserName == model.Email) && x.Password == model.Password)
                .Where(x => x.IsActive == true)
                .Select(x => new UserModel
                {
                   Id = x.Id,
                   UserName = x.UserName,
                   Password = x.Password,
                   ConfirmPassword = x.ConfirmPassword,
                   DateOfBirth = x.DateOfBirth,
                   Address = x.Address,
                   Address1 = x.Address1,
                   FullName = x.FullName,
                   Email = x.Email,
                   Point = x.Point,
                   PhoneNumber = x.PhoneNumber,
                   Role = x.Role,
                   Gender = x.Gender
                }).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserModel DoLoginAdmin(LoginModel model)
        {
            try
            {
                model.Password = CommonFunc.CalculateMD5Hash(model.Password);
                var user = _context.Users.Where(x => (x.Email == model.Email || x.UserName == model.UserName
                || x.UserName == model.Email) && x.Password == model.Password)
                .Where(x => x.IsActive == true)
                .Where(x => (x.Role == UserRole.Admin || x.Role == UserRole.Master))
                .Select(x => new UserModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Password = x.Password,
                    ConfirmPassword = x.ConfirmPassword,
                    Email = x.Email,
                    Address = x.Address,
                    Address1 = x.Address1,
                    PhoneNumber = x.PhoneNumber,
                    DateOfBirth = x.DateOfBirth,
                    Role = x.Role,
                    Point = x.Point
                }).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DoRegister(UserModel model)
        {
            try
            {
                if (model.Image != null)
                {
                    string path = "~/images/user/" + model.FileImage.FileName;
                    // delete existing image
                    if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        model.ImagePath = path;
                    }
                    else
                    {
                        model.FileImage.SaveAs(HttpContext.Current.Server.MapPath(path));
                        model.ImagePath = path;
                    }                   
                }

                var user = new User
                {
                    UserName = model.UserName,
                    FullName = model.FullName,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Email = model.Email,
                    Address = model.Address,
                    Address1 = model.Address1,
                    DateOfBirth = model.DateOfBirth,
                    Point = model.Point,
                    Role = UserRole.Normal,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Today,
                    CreateBy = model.CreateBy,
                    IsActive = true,
                    Token = model.Token,
                    ImagePath = model.ImagePath
                };

                _context.Users.Add(user);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<UserModel> GetListUser()
        {
            try
            {
                return _context.Users.Where(x => (x.IsDeleted == false && x.Role != UserRole.Master && x.Role != 
                UserRole.Admin))
                 .Select(x => new UserModel
                 {
                     UserName = x.UserName,
                     FullName = x.FullName,
                     Password = x.Password,
                     ConfirmPassword = x.ConfirmPassword,
                     Email = x.Email,
                     Address = x.Address,
                     Address1 = x.Address1,
                     DateOfBirth = x.DateOfBirth,
                     Point = x.Point,
                     PhoneNumber = x.PhoneNumber,                            
                     Active = true,
                     Token = x.Token,
                     ImagePath = x.ImagePath,
                     Id = x.Id
                 });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<UserModel> GetListUserAll()
        {
            try
            {
                return _context.Users.Where(x => (x.IsDeleted == false))
                 .Select(x => new UserModel
                 {
                     UserName = x.UserName,
                     FullName = x.FullName,
                     Password = x.Password,
                     ConfirmPassword = x.ConfirmPassword,
                     Email = x.Email,
                     Address = x.Address,
                     Address1 = x.Address1,
                     DateOfBirth = x.DateOfBirth,
                     Point = x.Point,
                     PhoneNumber = x.PhoneNumber,
                     Active = true,
                     Token = x.Token,
                     ImagePath = x.ImagePath,
                     Id = x.Id
                 });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _context.Users.Where(x => (x.Id == id && x.IsActive == true)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public User GetUserbyUserName(string username)
        {
            try
            {
                return _context.Users.Where(x => (x.UserName == username && x.IsActive == true)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool InsertOrUpdate(UserModel model)
        {
            try
            {
                var existingUser = _context.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                string path = "~/images/user/";
                if (existingUser != null)
                {
                    existingUser.Address = model.Address;
                    existingUser.Address1 = model.Address1;
                    existingUser.PhoneNumber = model.PhoneNumber;
                    existingUser.Email = model.Email;

                    if (model.FileImage != null)
                    {
                        if (File.Exists(HttpContext.Current.Server.MapPath(existingUser.ImagePath)))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath(existingUser.ImagePath));
                        }

                        model.FileImage.SaveAs(HttpContext.Current.Server.MapPath(path + model.FileImage.FileName));
                        existingUser.ImagePath = path + model.FileImage.FileName;
                    }

                    existingUser.FullName = model.FullName;
                    existingUser.LastModifiedBy = model.LastModifiedBy;
                    existingUser.DateOfBirth = model.DateOfBirth;
                    existingUser.ModifyDate = DateTime.Today;

                    _context.Entry(existingUser).State = EntityState.Modified;
                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdatePoint(long id, int diem)
        {
            throw new NotImplementedException();
        }
    }
}
