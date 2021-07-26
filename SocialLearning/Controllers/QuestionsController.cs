using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialLearning.Business.Abstract;
using SocialLearning.Business.Concrete;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var listquestions = await _questionService.GetAllQuestions();
            return Ok(listquestions);
        }
        [HttpGet("questionbyEducationId/{educationId}/{lessonId}")]
        public async Task<List<Question>> GetQuestionByEducationId(int educationId, int lessonId)
        {
            return await _questionService.GetQuestionByEducationId(educationId, lessonId);

        }
        [HttpGet("questionbyLessonId/{id}")]
        public async Task<List<Question>> GetQuestionByLessonId(int id)
        {
            return await _questionService.GetQuestionByLessonId(id);

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
           
            var createdquestion = await  _questionService.CreateQuestion(question);
 
            return  CreatedAtAction("Get", new { id = createdquestion.ID }, createdquestion);
        }
        [HttpGet("{id}")]
      
        public async Task<IActionResult> Get(int id)
        {
            var questions = await _questionService.GetQuestionById(id);
            if (questions != null)
            {
                return Ok(questions);
            }

            return NotFound();
            
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if ( await _questionService.GetQuestionById(id)!=null) { 
           await _questionService.DeleteQuestion(id);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Question question)
        {
            if ( await _questionService.GetQuestionById(question.ID) != null)
            {
                return Ok( await _questionService.UpdateQuestion(question));
            }
            return NotFound();




        }
    }
}
