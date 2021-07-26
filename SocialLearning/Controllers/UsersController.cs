using FluentValidation.Results;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class UsersController : ControllerBase 
    {
     

       
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
           
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            
            var listedusers = await _userService.GetAllUsers();

            return Ok(listedusers);
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User user)
        {
          var createduser= await _userService.CreateUser(user);
            return CreatedAtAction("Get", new { id=createduser.ID} , createduser);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            if ( await _userService.GetUserById(user.ID) != null)
            {
                return Ok(await _userService.UpdateUser(user));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _userService.GetUserById(id) != null)
            {
               await _userService.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
    }

}
