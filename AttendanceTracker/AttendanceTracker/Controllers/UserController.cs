using AttendanceTracker.Application.DTOs;
using AttendanceTracker.Application.Interfaces.IServices;
using AttendanceTracker.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userRepository)
        {
            this.userService = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
              try
            {
               var users = await userService.GetUser();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await userService.GetById(id);
                if (user != null)
                    return Ok(user);
                else
                    return NotFound("Not Found UserID.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult>  AddUser(User user)
        {
            try
            {
                var result = await userService.AddUser(user);
                if (result ==0)
                    return BadRequest("Not Inserted.");
                return Ok(result);
                
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult>   UpdateUser(User user)
        {
            try
            {
                var result = await userService.UpdateUser(user);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user= await userService.DeleteUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
