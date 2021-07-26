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
    public class LessonRepo : ILesson
    {
        public async Task<Lesson> CreateLesson(Lesson lesson)
        {
            using (var SLDbContext=new SLDbContext())
            {
                 SLDbContext.Lessons.Add(lesson);
               await  SLDbContext.SaveChangesAsync();
                return lesson;
            }
        }

        public async Task DeleteLesson(int id)
        {
            using (var SLDbContext = new SLDbContext())
            {
                var deletedLesson = await GetLessonById(id);

                SLDbContext.Lessons.Remove(deletedLesson);
               await SLDbContext.SaveChangesAsync();

            }
        }
        public async Task<List<Lesson>> GetAllLessons()
        {
            using (var SLDbContext=new SLDbContext()) {

                return await SLDbContext.Lessons.ToListAsync();
            
            }
        }

        public async Task<Lesson> GetLessonById(int id)
        {
            using (var SLDbContext=new SLDbContext()) {
                return await SLDbContext.Lessons.FindAsync(id);
            
            }
        }

        public async Task<Lesson> UpdateLesson(Lesson lesson)
        {
            using (var SLDbContext = new SLDbContext())
            {
                 SLDbContext.Lessons.Update(lesson);
                await SLDbContext.SaveChangesAsync();
                return lesson;

            }
        }
        public async Task<List<Lesson>> GetLessonsByEducationId(int educationId)
        {
            using (var SLDbContext = new SLDbContext())
            {
                var lessons = await SLDbContext.Lessons.ToListAsync();


                var categorizedLessons = lessons.FindAll(a => a.Education_Id == educationId).ToList();

                return categorizedLessons;
            }
        }
    }
}
