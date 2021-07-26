using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialLearning.Business.Abstract;
using SocialLearning.Business.Concrete;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;       
        }
       
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var listanswers = await _answerService.GetAllAnswers();

            return Ok(listanswers);
        }

        [HttpGet("GetAnswersByQuestionId/{id}")]
        public async Task<List<Answer>> GetAnswerByQuestionId(int id)
        {
            return await _answerService.GetAnswerByQuestionId(id);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Answer answer)
        {
            var createdanswer = await _answerService.CreateAnswer(answer);
            return CreatedAtAction("Get", new { id = createdanswer.ID }, createdanswer);
        }
        [HttpGet ("{id}")]
       
        public async Task<IActionResult> Get(int id)
        {
            if ( _answerService.GetAnswerById(id) != null)
            {
                var answers = await _answerService.GetAnswerById(id);
                return Ok(answers);
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Answer answer)
        {
            if (await _answerService.GetAnswerById(answer.ID) != null)
            {
                return Ok(await _answerService.UpdateAnswer(answer));
            }
            return NotFound();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if ( await _answerService.GetAnswerById(id) != null)
            {
               await  _answerService.DeleteAnswer(id);
                return Ok();

            }
            return NotFound();
        }
    }
   
}


