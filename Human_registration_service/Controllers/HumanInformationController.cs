using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Human_Registration_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanInformationController
    {
        private IHumanInformationRepository _humanInformation;

        public HumanInformationController(IHumanInformationRepository humanInformation)
        {
            _humanInformation = humanInformation;
        }
        [HttpPost("CreateNewAccount")]
        public HumanInformation AddNewUser([FromQuery] string name, string lastName, string email, int phoneNumber, int personalNumber)
        {
            return null;
            //return _humanInformation.SignUpNewAccount(name, lastName, email, phoneNumber,personalNumber);
        }
    }
}
