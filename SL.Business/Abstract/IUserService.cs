using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SocialLearning.Business.ValidationRules;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Abstract
{
    public interface IUserService 
    {
        Task<List<User>> GetAllUsers();
       Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
       

    }
}
