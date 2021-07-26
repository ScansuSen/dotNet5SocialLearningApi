using Microsoft.EntityFrameworkCore;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess.Concrete
{
   public  class UserRepo : IUser
    {
        public async Task< User> CreateUser(User user)
        {
            using (var SLDbContext=new SLDbContext())
            {
                SLDbContext.Users.Add(user);
               await SLDbContext.SaveChangesAsync();
                return user;

            }
        }

        public async Task DeleteUser(int id)
        {
            using (var SLDbContext=new SLDbContext())
            {
                var deletedUser= await GetUserById(id);

                SLDbContext.Users.Remove(deletedUser);
               await SLDbContext.SaveChangesAsync();
                
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (var SLDbContext = new SLDbContext())
            {
                return await SLDbContext.Users.ToListAsync();
            }
        }

        public async Task< User> GetUserById(int id)
        {
            using (var SLDbContext=new SLDbContext()) {

                return await SLDbContext.Users.FindAsync(id);
            
            }
        }

        public async Task<User> UpdateUser(User user)
        {
           using(var SLDbContext=new SLDbContext())
            {
                SLDbContext.Users.Update(user);
                await SLDbContext.SaveChangesAsync();
                return user;
            }
        }
    }
}
