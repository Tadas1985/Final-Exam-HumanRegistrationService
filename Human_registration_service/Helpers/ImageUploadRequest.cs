using Microsoft.AspNetCore.Http;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;


namespace Human_Registration_Service.Helpers
{
    public class ImageUploadRequest
    {
        

        
        //[AllowedExtentions(new string[]{".png", ".jpg"})]
        public IFormFile Image { get;set; }

        public static System.Drawing.Image ResizeImage(System.Drawing.Image img)
        {
            
            return (System.Drawing.Image)(new Bitmap(img, new Size(200, 200))) ;
            //return (Image)(new Bitmap(img, new Size(0, 200)));
        }

       
    }
}
