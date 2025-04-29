using System.Security.Cryptography;
using itinera_io_backend.Models.DTOS;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            bool success = await _userServices.CreateAccount(user);
            if (success) 
                return Ok(new {Success=true});
            else
                return BadRequest (new{Success = false, Message ="Account Creation Failed. User exists."});
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            string success= await _userServices.Login(user);
            if (success!=null)
            {
                return Ok (new {Token= success});
            }else
            {
                return Unauthorized(new{Message ="Login failed. Wrong username or Password."});
            }

        }

        [HttpGet("GetUserInfoByEmail/{email}")]
        public async Task<IActionResult> GetUserInfoByEmail (string email )
        {
        var user = await _userServices.GetUserInfoByEmailAsync(email);
       
            if (user!=null) return Ok(user);
            else
            {
            return BadRequest(new {Message = "No User Found."});
            }
            
        }

        [HttpGet("GetUserInfoById/{id}")]
        public async Task<IActionResult> GetUserInfoById (int id )
        {
        var user = await _userServices.GetUserInfoByIdAsync(id);
       
            if (user!=null) return Ok(user);
            else
            {
            return BadRequest(new {Message = "No User Found."});
            }
            
        }

        
    
        [HttpPut("EditUser")]
        [Authorize] 
        public async Task<IActionResult> EditUser([FromBody] UserInfoDTO user)
        {
            var success = await _userServices.EditUserAsync(user);

            if (success) return Ok(new { Success = true });

            return BadRequest(new { Message = "No user info was edited" });
        }
    
    }
}