namespace RockGym.Models.Auth
{
    public static class Roles
    {
        public const string RegisteredUser = nameof(RegisteredUser);
        public const string AdminUser = nameof(AdminUser);

        public static readonly IReadOnlyCollection<string> All = new[] { RegisteredUser, AdminUser };
    }
}
