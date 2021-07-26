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
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;
       
        public LessonsController(ILessonService lessonService )
        {
            _lessonService = lessonService;

        }
        [HttpGet]
        [Route("all")]
        public async Task< IActionResult> Get()
        {
            var listlessons= await _lessonService.GetAllLessons();
            return Ok(listlessons);
        }
        [HttpGet("{id}")]
       
        public async Task<IActionResult> Get(int id)
        {
            if ( _lessonService.GetLessonById(id) != null)
            {
                var lessons = await _lessonService.GetLessonById(id);
                return Ok(lessons);
            }
            return NotFound();
        }
        [HttpGet("GetLessonsByEducationId/{educationId}")]
        public async Task<List<Lesson>> GetLessonsByEducationId(int educationId)
        {
            return await _lessonService.GetLessonsByEducationId(educationId);
        } 
            [HttpPost]

        public async Task<IActionResult> Post([FromBody] Lesson lesson)
        {
            var createdlesson = await _lessonService.CreateLesson(lesson);
            return CreatedAtAction("Get", new { id = createdlesson.ID }, createdlesson);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Lesson lesson)
        {
            if (await _lessonService.GetLessonById(lesson.ID) != null)
            {
                return Ok(await _lessonService.UpdateLesson(lesson));
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> Delete(int id)
        {
            if (await _lessonService.GetLessonById(id) != null)
            {
                await _lessonService.DeleteLesson(id);
                return Ok();

            }
            return NotFound();
        }
    }
}
