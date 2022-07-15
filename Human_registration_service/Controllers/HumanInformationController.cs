using Human_Registration_Service.Helpers;
using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;

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
        [HttpPost("addHumanInfromation")]
        public string AddNewHumanInformation([FromQuery] string userName, string name, string lastName, UInt64 personalNumber, UInt64 phoneNumber, string email, [FromForm] Helpers.ImageUploadRequest ProfileImage)
        {
            if (!Validator.IsNotEmpty(userName))
                return "user name is not valid";
            if (!(Validator.IsNotEmpty(name) &&
            Validator.IsNotEmpty(lastName) &&
            Validator.IsNumberNotZero(personalNumber) &&
            Validator.IsNumberNotZero(phoneNumber) &&
            Validator.IsNotEmpty(email)))
            {
                return "All fields must contain alphnumeric symbols";
            }
            if (!Validator.IsImageTypeCorrect(ProfileImage.Image.ContentType))
                return "Image type is not valid (only jpeg and png accepted)";
            using var memoryStream = new MemoryStream();
            ProfileImage.Image.CopyTo(memoryStream);
            var tempImage = ImageUploadRequest.ResizeImage(Image.FromStream(memoryStream));

            var ms = new MemoryStream();
            tempImage.Save(ms, ProfileImage.Image.ContentType == "image/png" ? System.Drawing.Imaging.ImageFormat.Png : System.Drawing.Imaging.ImageFormat.Jpeg);
            return _humanInformation.AddNewHuman(userName, name, lastName, personalNumber, phoneNumber, email, ms.ToArray()) ? "OK" : "Failed";

            //return _humanInformation.SignUpNewAccount(name, lastName, email, phoneNumber,personalNumber);
        }
        //[HttpPost"UpdateHumanInformation"]
        //public void UpdateHumanImage([FromForm] string name, string lastName, string email, int phoneNumber, int personalNumber)
        //{

        //}
        [HttpGet("getHumanInformation")]
        public HumanInformation GetHumanInformation([FromQuery] string userName)
        {
            return _humanInformation.GetHumanInformation(userName);
        }
        [HttpGet("getHumanInformationPhotoBytes")]
        public string GetHumanInformationPhotoBytes([FromQuery] string userName)
        {
            return BitConverter.ToString( _humanInformation.GetHumanInformationPhotoBytes(userName)); // Paklausk mokytojo ar ok, jei ne grazin toString(), istring bitConverter
        }
        

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
        [HttpPut("updateName")]
        public void UpdateName([FromQuery] string userName, string name)
        {
            if (Validator.IsNotEmpty(name))
                _humanInformation.UpdateName(userName, name);

            //  Authentication.JwtService.


        }
        [HttpPut("updatePhoneNumber")]
        public void UpdatePhoneNumber([FromQuery] UInt64 phoneNumber, UInt64 newPhoneNumber)
        {
             _humanInformation.UpdatePhoneNumber(phoneNumber, newPhoneNumber);
        }
        [HttpPut("updatePersonalNumber")]
        public void UpdatePersonalNumber([FromQuery] UInt64 personalNumber, UInt64 newPersonalNumber)
        {
            _humanInformation.UpdatePersonalNumber(personalNumber, newPersonalNumber);
        }
        [HttpPut("updateEmail")]
        public void UpdateEmail([FromQuery] string email, string newEmail)
        {
            _humanInformation.UpdateEmail(email, newEmail);
        }

    }
}





  
