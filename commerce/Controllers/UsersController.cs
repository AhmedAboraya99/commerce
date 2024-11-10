using commerce.DTOs;
using commerce.Interfaces;
using commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> DisplayAllUsers()
        {

            var AllUsers = await _userRepo.GetUsers();
    
            
            if (AllUsers == null)
            {
                return NotFound();
            }

            return Ok(AllUsers);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser(UserDTO userdto)
        {
            var userRes = await _userRepo.AddUser(userdto);
            
            if (userRes == null) 
                return NotFound();

            return CreatedAtAction(nameof(DisplayUerById), new {id = userRes.Id}, userdto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> DisplayUerById(int id)
        {
           var user = await _userRepo.GetUserById(id);
           

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult DisplayUerByName(string name)
        {
            var user = _userRepo.GetUserByName(name);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser( UserDTO userdto)
        {
            var Newusr = _userRepo.UpdateUser(userdto);
           
            if (Newusr == null)
            {
                return NotFound();
            }

            return NoContent();
        }
/*        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            var RemovedUSer = _context.Users.FirstOrDefault(u => u.Id == id);
            if(RemovedUSer == null)
            {
                return NotFound();
            }

            _context.Users.Remove(RemovedUSer);
            _context.SaveChanges();
           
            return Ok(RemovedUSer);
        }*/

    }
}
