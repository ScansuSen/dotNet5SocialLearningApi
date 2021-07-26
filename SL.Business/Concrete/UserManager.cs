using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using SocialLearning.Business.Abstract;
using SocialLearning.Business.ValidationRules;
using SocialLearning.DataAccess;
using SocialLearning.DataAccess.Concrete;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Concrete
{
   public class UserManager : IUserService 
    {


        private IUser _userRepo;
        public UserManager()
        {
            _userRepo = new UserRepo();
           
        }

        public async Task< User> CreateUser(User user)
        {
            return await _userRepo.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepo.DeleteUser(id);
        }

        public async Task< List<User>> GetAllUsers()
        {
            return await _userRepo.GetAllUsers();
        }

       

        public async Task<User> GetUserById(int id)
        {
            return await _userRepo.GetUserById(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepo.UpdateUser(user);
        }
    }
}
