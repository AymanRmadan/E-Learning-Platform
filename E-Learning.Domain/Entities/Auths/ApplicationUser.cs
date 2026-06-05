namespace E_Learning.Domain.Entities.Auths
{
    public sealed class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsDisabled { get; set; }

        public Learner? Learner { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = [];
    }
}
