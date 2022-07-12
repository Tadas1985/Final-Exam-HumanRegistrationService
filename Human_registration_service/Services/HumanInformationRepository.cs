using Human_Registration_Service.Context;

namespace Human_Registration_Service.Services
{
    public class HumanInformationRepository :IHumanInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public HumanInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
