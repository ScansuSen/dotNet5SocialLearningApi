using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Abstract
{
   public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessons();
        Task<Lesson> GetLessonById(int id);
        Task<Lesson> CreateLesson(Lesson lesson);
        Task<Lesson> UpdateLesson(Lesson lesson);
        Task DeleteLesson(int id);
        Task<List<Lesson>> GetLessonsByEducationId(int educationId);
    }
}
