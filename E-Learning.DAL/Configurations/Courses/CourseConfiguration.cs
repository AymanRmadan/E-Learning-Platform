namespace E_Learning.DAL.Configurations.Courses;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(250);

        builder.Property(c => c.Description)
            .HasMaxLength(2000);

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);

        builder.Property(c => c.RequiresApproval)
            .HasDefaultValue(true);
    }
}