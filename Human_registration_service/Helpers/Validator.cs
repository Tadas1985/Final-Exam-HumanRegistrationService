using Human_Registration_Service.Models;
using System;

namespace Human_Registration_Service.Helpers
{
    public class Validator
    {
        public static bool IsNotEmpty(string input)
        {

            return input!= null && input.Trim().Length > 0;
                
        }
        public static bool IsNumberNotZero( UInt64 input)
        {
            return input != 0;
        }
        public static bool IsImageTypeCorrect(string imageType)
        {
            return imageType == "image/png" || imageType == "image/jpeg";
        }
    }
}





