using SocialLearning.Business.Abstract;
using SocialLearning.DataAccess.Concrete;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private LessonRepo _lessonRepo;
        public LessonManager()
        {
            _lessonRepo = new LessonRepo()
;
        }
        public async Task< Lesson> CreateLesson(Lesson lesson)
        {
            return await _lessonRepo.CreateLesson(lesson);
        }

        public async  Task DeleteLesson(int id)
        {
           await _lessonRepo.DeleteLesson(id);
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _lessonRepo.GetAllLessons();
        }

        public async Task<Lesson> GetLessonById(int id)
        {
            return await _lessonRepo.GetLessonById(id);
        }

        public async Task<Lesson> UpdateLesson(Lesson lesson)
        {
            return  await _lessonRepo.UpdateLesson(lesson);
        }
        public async Task<List<Lesson>> GetLessonsByEducationId(int educationId)
        {
            return await _lessonRepo.GetLessonsByEducationId(educationId);
        }
    }
}
