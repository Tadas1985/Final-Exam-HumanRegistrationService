using Human_Registration_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Human_Registration_Service.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<HumanInformation> HumanInformation { get; set; }
        //public DbSet<Image>Images { get; set; }
        public DbSet<Location>Locations { get; set; }
        public DbSet<UserInformation>UserInformation { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
    }
}
