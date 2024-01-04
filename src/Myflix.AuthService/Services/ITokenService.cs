namespace Myflix.AuthService.Services
{
    public interface ITokenService
    {
        public string GenerateAuthToken(string username);
    }
}
