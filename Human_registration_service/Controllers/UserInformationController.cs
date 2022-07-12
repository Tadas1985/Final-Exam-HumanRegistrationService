using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Human_Registration_Service.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class UserInformationController
    {
        IUserInformationRepository _userRepository;

        public UserInformationController(IUserInformationRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("AddNewUser")]
        public UserInformation AddNewUser([FromForm] string userName, [FromForm] string password)
        {
            return _userRepository.AddNewUser(userName, password);
        }
        [HttpPost("LogIn")]
        public bool LogIn([FromForm] string userName, [FromForm] string password)
        {
            return _userRepository.LogIn(userName, password);   
        }
    }
}
