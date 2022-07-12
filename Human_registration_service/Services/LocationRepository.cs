using Human_Registration_Service.Context;

namespace Human_Registration_Service.Services
{
    public class LocationRepository: ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
