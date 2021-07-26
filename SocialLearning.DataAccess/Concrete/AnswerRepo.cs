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
   public class AnswerRepo : IAnswer
    {
        public async  Task<Answer> CreateAnswer(Answer answer)
        {
            using (var SLDbContext=new SLDbContext()) {

                SLDbContext.Answers.Add(answer);
               await SLDbContext.SaveChangesAsync();
                return answer;
            
            }
        }

        public async Task DeleteAnswer(int id)
        {
            using (var SLDbContext = new SLDbContext())
            {
                var deletedanswer = await GetAnswerById(id);
                SLDbContext.Answers.Remove(deletedanswer);
               await SLDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            using (var SLDbContext=new SLDbContext())
            {
               return await SLDbContext.Answers.ToListAsync();
               
            }
        }

        public async Task <Answer> GetAnswerById(int id)
        {
            using (var SLDbContext=new SLDbContext())
            {
               return await SLDbContext.Answers.FindAsync(id);
                
            }
        }

        public async Task<List<Answer>> GetAnswerByQuestionId(int QuestionId)
        {

            using (var SLDbContext=new SLDbContext())
            {
                var answers = await SLDbContext.Answers.ToListAsync();
                var categorizedAnswer = answers.FindAll(a => a.Question_Id== QuestionId).ToList();
                return categorizedAnswer;
            }

        }
       

       

        public async Task<Answer> UpdateAnswer(Answer answer)
        {
            using (var SLDbContext = new  SLDbContext())
            {
                SLDbContext.Answers.Update(answer);
              await  SLDbContext.SaveChangesAsync();
                return answer;
            }
        }
    }
}
