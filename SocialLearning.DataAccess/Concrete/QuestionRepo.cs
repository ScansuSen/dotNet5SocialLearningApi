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
    public class QuestionRepo : IQuestion
    {
        public async Task<Question> CreateQuestion(Question question)
        {
            using (var SLDbContext = new SLDbContext())
            {
                SLDbContext.Questions.Add(question);
               await SLDbContext.SaveChangesAsync();
                return question;

            }
        }

        public async Task DeleteQuestion(int id)
        {
            using (var SLDbContext = new SLDbContext())
            {
                var deletedQuestion = await GetQuestionById(id);
                SLDbContext.Questions.Remove(deletedQuestion);
                await SLDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            using (var SLDbContext = new SLDbContext())
            {
                return await SLDbContext.Questions.ToListAsync();
            }
        }
        public async Task<List<Question>> GetQuestionsByEducationId(int educationId,int lessonId)
        {
            using (var SLDbContext = new SLDbContext())
            {
                var questions =  await SLDbContext.Questions.ToListAsync();

              
               var categorizedQuestions = questions.FindAll(a => a.Education_Id == educationId || a.Lesson_Id == lessonId).ToList();
               
                return categorizedQuestions;
            }
        }

        public async Task<List<Question>> GetQuestionsByLessonId(int lessonId) { 
            using (var SLDbContext = new SLDbContext())
            {
                var questions = await SLDbContext.Questions.ToListAsync();


                var categorizedQuestions = questions.FindAll(a => a.Lesson_Id == lessonId).ToList();

                return categorizedQuestions;
            }
        }

        public async Task<Question> GetQuestionById(int id)
        {
            using (var SLDbContext = new SLDbContext())
            {
                return await SLDbContext.Questions.FindAsync(id);

            }
        }

        public async Task<Question> GetRepliedQuestion(int id)
        {
            using (var SLDbContext = new SLDbContext())
            {
                return await SLDbContext.Questions.FindAsync(id);

            }
        }

        

        public async Task<Question> UpdateQuestion(Question question)
        {
            using (var SLDbContext = new SLDbContext())
            {

                SLDbContext.Questions.Update(question);
                await SLDbContext.SaveChangesAsync();
                return question;

            }
        }


    }
}