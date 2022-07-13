using Human_Registration_Service.Helpers;
using Human_Registration_Service.Models;
using Human_Registration_Service.Services;
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
            if (!Validator.IsImageTypeCorrect(ProfileImage.Image.ContentType))
                return "Image type is not valid (only jpeg and png accepted)";
            using var memoryStream = new MemoryStream();
            ProfileImage.Image.CopyTo(memoryStream);
            var tempImage = ImageUploadRequest.ResizeImage(Image.FromStream(memoryStream));
            
            var ms = new MemoryStream();
            tempImage.Save(ms, ProfileImage.Image.ContentType== "image/png"?System.Drawing.Imaging.ImageFormat.Png: System.Drawing.Imaging.ImageFormat.Jpeg);
            return _humanInformation.AddNewHuman(name,lastName,personalNumber,phoneNumber,email, ms.ToArray())? "OK": "Failed";
            
            //return _humanInformation.SignUpNewAccount(name, lastName, email, phoneNumber,personalNumber);
        }
        //[HttpPost"UpdateHumanInformation"]
        //public void UpdateHumanImage([FromForm] string name, string lastName, string email, int phoneNumber, int personalNumber)
        //{
            
        //}
    }
}





  
