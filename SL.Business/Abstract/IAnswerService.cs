using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Abstract
{
  public  interface IAnswerService
    {
        Task<List<Answer>> GetAllAnswers();
      
        Task<Answer> CreateAnswer(Answer answer);
        Task<Answer> UpdateAnswer(Answer answer);
        Task DeleteAnswer(int id);
        Task<Answer>  GetAnswerById(int id);

        Task< List<Answer>> GetAnswerByQuestionId(int id);
    } 

}
