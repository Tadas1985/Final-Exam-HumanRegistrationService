using System;

namespace Human_Registration_Service.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
}
