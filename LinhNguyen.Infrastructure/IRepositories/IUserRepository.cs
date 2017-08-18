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
        IQueryable<UserModel> GetAllUser();
        bool InsertUser(UserModel model);
        bool UpdateUser(UserModel model);
        void DeleteUser(int id);
        

    }
}
