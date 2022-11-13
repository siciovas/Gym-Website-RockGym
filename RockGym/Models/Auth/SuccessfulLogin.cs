namespace RockGym.Models.Auth
{
    public class SuccessfulLogin
    {
        public string AccessToken { get; set; }
        public SuccessfulLogin(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
