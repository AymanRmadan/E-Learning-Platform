namespace E_Learning.DAL.Configurations
{
    public class LearnerConfiguration : IEntityTypeConfiguration<Learner>
    {
        public void Configure(EntityTypeBuilder<Learner> builder)
        {
            builder.HasKey(l => l.Id);

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