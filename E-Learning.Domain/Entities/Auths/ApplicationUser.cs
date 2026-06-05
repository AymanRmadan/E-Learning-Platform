namespace E_Learning.Domain.Entities.Auths
{
    public sealed class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; } = string.Empty;
        public Learner? Learner { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = [];
    }
}
