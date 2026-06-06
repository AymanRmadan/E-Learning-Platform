namespace E_Learning.DAL.Configurations
{
    public class LearnerConfiguration : IEntityTypeConfiguration<Learner>
    {
        public void Configure(EntityTypeBuilder<Learner> builder)
        {
            builder.HasKey(l => l.Id);
            // Id No Identity
            builder.Property(l => l.Id)
           .ValueGeneratedNever();


            // One-to-One مع ApplicationUser
            builder.HasOne(l => l.User)
           .WithOne(u => u.Learner)
           .HasForeignKey<Learner>(l => l.UserId)
           .OnDelete(DeleteBehavior.Cascade);


            builder.Property(l => l.FullName)
                .HasMaxLength(250);

            builder.Property(l => l.Email)
                .HasMaxLength(150);

            builder.Property(l => l.NationalId)
                .HasMaxLength(50);

            builder.Property(l => l.Department)
                   .HasMaxLength(250);
        }
    }
}