using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess.Abstract
{
    interface IQuestion
    {

        Task<List<Question>> GetAllQuestions();
        Task<Question> CreateQuestion(Question question);
        Task<Question> GetQuestionById(int id);
        Task<Question> UpdateQuestion(Question question);
        Task DeleteQuestion(int id);
       
        Task<List<Question>> GetQuestionsByEducationId(int educationId, int lessonId);




    }
}
