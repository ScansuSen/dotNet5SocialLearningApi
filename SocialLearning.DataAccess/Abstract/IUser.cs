using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess
{
    public interface IUser
    {
       Task< List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);

    }
}
