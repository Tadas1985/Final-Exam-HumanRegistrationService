namespace Human_Registration_Service.Authentication
{
    public interface IJwtService
    {
        public string GetJwtToken(string username);
    }
}
