using LinhNguyen.Domain.Entities;
using LinhNguyen.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        bool DoRegister(UserModel model);
        UserModel DoLogin(LoginModel model);
        IQueryable<UserModel> GetListUser();
        IQueryable<UserModel> GetListUserAll();
        bool InsertOrUpdate(UserModel model);
        bool Delete(int id);
        bool AddContact(ContactUsModel model);
        bool UpdatePoint(long id, int diem);
        UserModel DoLoginAdmin(LoginModel model);
        User GetUserById(int id);
        User GetUserbyUserName(string username);
    }
}
