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
   public class QuestionManager : IQuestionService
    {
        private QuestionRepo _questionRepo;
        public QuestionManager()
        {
            _questionRepo = new QuestionRepo();
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            return await _questionRepo.CreateQuestion(question);
        }

        public async Task DeleteQuestion(int id)
        {
            await _questionRepo.DeleteQuestion(id);
        }

        public async Task< List<Question>> GetAllQuestions()
        {
            return await _questionRepo.GetAllQuestions();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _questionRepo.GetQuestionById(id);
        }

        public async Task<Question> UpdateQuestion(Question question)
        {
            return await _questionRepo.UpdateQuestion(question);
        }
        public async Task<List<Question>> GetQuestionByEducationId(int educationId, int lessonId)
        {
            return await _questionRepo.GetQuestionsByEducationId(educationId,lessonId);
        }
        public async Task<List<Question>> GetQuestionByLessonId(int id)
        {
            return await _questionRepo.GetQuestionsByLessonId(id);
        }
    }
}
