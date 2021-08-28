namespace Timesheets.Authentication
{
    public interface IUserService
    {
        TokenResponse Authenticate(string user, string password);

        string RefreshToken(string token);
    }
}