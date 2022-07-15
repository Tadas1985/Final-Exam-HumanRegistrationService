using Human_Registration_Service.Authentication;
using Human_Registration_Service.DTOs;
using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Human_Registration_Service.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class UserInformationController
    {
        IUserInformationRepository _userRepository;
        IJwtService _jwtService;
        IHumanInformationRepository _humanInformationRepository;

        public UserInformationController(IUserInformationRepository userRepository, IJwtService jwtService, IHumanInformationRepository humanInformationRepository)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _humanInformationRepository = humanInformationRepository;
            
        }
        [HttpPost("AddNewUser")]
        public bool AddNewUser([FromForm] string userName, [FromForm] string password)
        {
            return _userRepository.AddNewUser(userName, password);
        }
        //[HttpPost("LogIn")]
        //public string LogIn([FromForm] string userName, [FromForm] string password)
        //{
        //    return _userRepository.LogIn(userName, password);   
        //}
        [HttpPost("logIn")]
        public async Task<ActionResult<string>> LogIn(UserDTO request)
        {
            if (!_userRepository.LogIn(request.UserName, request.Password, out string role ))  //out string role
                return new BadRequestObjectResult($"Bad username or password");
            string token = _jwtService.GetJwtToken(request.UserName, role);
            return token;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme , Roles = "user" )]
        [HttpGet("getString")]
        public string Getstring()
        {
           // Request.Headers;

            return "Hi";
        }
      
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("deleteUser")]
        public bool Getstring(string userName)
        {

            return _userRepository.DeleteUser(userName);
            
        }

    }
}
