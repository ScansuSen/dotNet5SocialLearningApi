using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess.Abstract
{
    interface IAnswer
    {
        Task<List<Answer>> GetAllAnswers();
        
        Task<Answer> CreateAnswer(Answer answer);
        Task<Answer> GetAnswerById(int id);
        Task<Answer> UpdateAnswer(Answer answer);
        Task DeleteAnswer(int id);
    }
}
