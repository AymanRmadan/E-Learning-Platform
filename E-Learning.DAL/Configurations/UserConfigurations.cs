using E_Learning.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Learning.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.OwnsMany(u => u.RefreshTokens).ToTable("RefreshTokens")
                .WithOwner().HasForeignKey("UserId");

            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.LastName).HasMaxLength(100);


            var user = new ApplicationUser
            {
                Id = DefaultUsers.AdminId,
                UserName = "ayman",
                NormalizedUserName = "AYMAN",
                Email = "admin@e-learning.com",
                NormalizedEmail = "ADMIN@E-LEARNING.COM",
                EmailConfirmed = true,
                FirstName = "Ayman",
                LastName = "Ramadan",
                SecurityStamp = "b3c8f352-7a2e-4b61-9c8a-7235aef214db",
                ConcurrencyStamp = "c4d9e163-8b3f-5c72-0d9b-8346bfa325ec",
                IsDisabled = false,
                PasswordHash = "AQAAAAEAACcQAAAAEExampleStaticHashHere123456=="
            };

            builder.HasData(user);
        }
    }
}