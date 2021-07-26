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
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public  EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]



        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var listeducations= await _educationService.GetAllEducations();

            return Ok(listeducations); 
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Education education)
        {
           var creatededucation= await  _educationService.CreateEducation(education);
            return CreatedAtAction("Get", new { id = creatededucation.ID }, creatededucation);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            if (  _educationService.GetEducationById(id) != null) {
                var educations = await _educationService.GetEducationById(id);
                return Ok(educations);
                    }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Education education)
        {
            if (await _educationService.GetEducationById(education.ID) != null)
            {
                return Ok(await _educationService.UpdateEducation(education));
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _educationService.GetEducationById(id) != null)
            {
                await _educationService.DeleteEducation(id);
                return Ok();

            }
            return NotFound();
        }
    }


}

