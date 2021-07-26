using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Abstract
{
    public interface IQuestionService
    {
       Task< List<Question>> GetAllQuestions();

        Task<Question> CreateQuestion(Question question);

        Task<List<Question>> GetQuestionByEducationId(int educationId, int lessonId);
        Task<Question> GetQuestionById(int id);
        Task<Question> UpdateQuestion(Question question);
        Task DeleteQuestion(int id);
        Task<List<Question>> GetQuestionByLessonId(int id);
    }
}
