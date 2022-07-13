using Microsoft.AspNetCore.Http;

namespace Human_Registration_Service.Helpers
{
    public class ImageUploadRequest
    {
        

        //[MaxFileSize(5*1024*1024)]
        // [AllowedExtentions(new string[]{".png", ".jpg"})]
        public IFormFile Image { get;set; }
    }
}
