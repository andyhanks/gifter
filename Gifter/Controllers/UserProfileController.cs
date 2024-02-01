using System;
using Microsoft.AspNetCore.Mvc;
using Gifter.Repositories;
using Gifter.Models;

namespace Gifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userProfileRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userprofile = _userProfileRepository.GetById(id);
            if (userprofile == null)
            {
                return NotFound();
            }
            return Ok(userprofile);
        }

        [HttpGet("GetUserWithPosts/{id}")]
        public IActionResult GetUserWithPosts(int id)
        {
            var userprofile = _userProfileRepository.GetUserPostsByUserId(id);
            return Ok(userprofile);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userprofile)
        {
            _userProfileRepository.Add(userprofile);
            return CreatedAtAction("Get", new { id = userprofile.Id }, userprofile);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _userProfileRepository.Update(userProfile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userProfileRepository.Delete(id);
            return NoContent();
        }
    }
}