namespace Inovola.Application.Interfaces
{
    public interface IJWTService
    {
        string GenerateJwtToken(string username);
    }
}
