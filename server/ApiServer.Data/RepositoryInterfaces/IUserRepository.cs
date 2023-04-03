using ApiServer.Model;
using ApiServer.SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Data.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string username, string email);
        Task<User> GetUserByUserName(string username);
        Task<User> GetUserByEmail(string email);

    }
}
