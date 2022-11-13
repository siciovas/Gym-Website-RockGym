namespace RockGym.Models.Auth
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public UserDto(string id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
