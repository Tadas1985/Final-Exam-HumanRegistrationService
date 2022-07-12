using Human_Registration_Service.Context;

namespace Human_Registration_Service.Services
{
    public class ImageRepository: IImageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
