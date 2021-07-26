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
   
    public class AnswerManager : IAnswerService
    {
        private AnswerRepo _answerRepo;
        public AnswerManager()
        {
            _answerRepo = new AnswerRepo();
        }
        public async Task<Answer> CreateAnswer(Answer answer)
        {
            return await _answerRepo.CreateAnswer(answer);
        }
        public async Task<List<Answer>> GetAnswerByQuestionId(int id)
        {
            return await _answerRepo.GetAnswerByQuestionId(id);
        }
        public async Task DeleteAnswer(int id)
        {
            await _answerRepo.DeleteAnswer(id);
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            return await _answerRepo.GetAnswerById(id);
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            return await _answerRepo.GetAllAnswers();
        }

        public async Task<Answer> UpdateAnswer(Answer answer)
        {
            return await _answerRepo.UpdateAnswer(answer);

        }
    }
}
