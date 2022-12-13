namespace RockGym.Models.Auth
{
    public class SuccessfulLogin
    {
        public string AccessToken { get; set; }
        public int? SubId { get; set; }
        public SuccessfulLogin(string accessToken, int subId)
        {
            AccessToken = accessToken;
            SubId = subId;
        }

        public SuccessfulLogin(string accessToken)
        {
            AccessToken = accessToken;
            SubId = null;
        }
    }
}
