namespace E_Learning.DAL.Configurations.Learners
{
    public class LearnerConfiguration : IEntityTypeConfiguration<Learner>
    {
        public void Configure(EntityTypeBuilder<Learner> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.FullName)
                .IsRequired().
                HasMaxLength(150);

            builder.Property(l => l.Email)
                .IsRequired().
                HasMaxLength(50);

            builder.Property(l => l.NationalId)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(l => l.Department)
                   .HasMaxLength(100);


            builder.HasIndex(l => l.Email).IsUnique(); // To Be Unique in DB
            builder.HasIndex(l => l.NationalId).IsUnique();
        }
    }
}
