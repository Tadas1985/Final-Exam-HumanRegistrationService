using Human_Registration_Service.Helpers;
using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpPost("AddHumanInfromation")]
        public string AddNewHumanInformation([FromQuery] string name, string lastName, UInt64 personalNumber, UInt64 phoneNumber, string email, [FromForm] Helpers.ImageUploadRequest ProfileImage )
        {
            if (!(Validator.IsNotEmpty(name) &&
            Validator.IsNotEmpty(lastName) &&
            Validator.IsNumberNotZero(personalNumber) &&
            Validator.IsNumberNotZero(phoneNumber) &&
            Validator.IsNotEmpty(email)))
            {
                return "All fields must contain alphnumeric symbols";
            }
            
            return _humanInformation.AddNewHuman(name,lastName,personalNumber,phoneNumber,email)? "OK": "Failed";
            
            //return _humanInformation.SignUpNewAccount(name, lastName, email, phoneNumber,personalNumber);
        }
        //[HttpPost"UpdateHumanInformation"]
        //public void UpdateHumanImage([FromForm] string name, string lastName, string email, int phoneNumber, int personalNumber)
        //{
            
        //}
    }
}
