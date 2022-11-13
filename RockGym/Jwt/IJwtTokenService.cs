namespace RockGym.Jwt
{
    public interface IJwtTokenService
    {
        string CreateAccessToken(string email, string userId, IEnumerable<string> userRoles);
    }
}
