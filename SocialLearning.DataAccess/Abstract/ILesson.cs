using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess.Abstract
{
  public  interface ILesson
    {
       Task< List<Lesson>> GetAllLessons();

       Task< Lesson >CreateLesson(Lesson lesson);
        Task<Lesson> GetLessonById(int id);
        Task<Lesson> UpdateLesson(Lesson lesson);
        Task DeleteLesson(int id);

        Task<List<Lesson>> GetLessonsByEducationId(int educationId);




    }
}
