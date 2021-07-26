using Microsoft.EntityFrameworkCore;
using SocialLearning.DataAccess.Abstract;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess.Concrete
{
   public class EducationRepo : IEducation
    {
        public async Task< Education> CreateEducation(Education education)
        {
            using (var SLDbContext=new SLDbContext())
            {
                SLDbContext.Educations.Add(education);
               await SLDbContext.SaveChangesAsync();
                return education;

            }
        }

        public async Task DeleteEducation(int id)
        {
            using (var SLDbContext=new SLDbContext())
            {
                var deletedEducation = await GetEducationById(id);
                SLDbContext.Educations.Remove(deletedEducation);
                await SLDbContext.SaveChangesAsync();
            }
        }

        public async Task< List<Education>> GetAllEducations()
        {
            using (var SLDbContext=new SLDbContext())
            {
                return await SLDbContext.Educations.ToListAsync();

            }
        }

        public async Task<Education> GetEducationById(int id)
        {
            using (var SLDbContext=new SLDbContext())
            {
                return await SLDbContext.Educations.FindAsync(id);
            }
        }

        public async Task<Education> UpdateEducation(Education education)
        {
            using (var SLDbContext=new SLDbContext())
            {
                SLDbContext.Educations.Update(education);
                await SLDbContext.SaveChangesAsync();
                return education;
            }
                
                    }
    }
}
