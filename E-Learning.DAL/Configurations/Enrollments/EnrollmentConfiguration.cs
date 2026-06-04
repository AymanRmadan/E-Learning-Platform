namespace E_Learning.DAL.Configurations.Enrollments
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.Id);

            //A learner cannot enroll twice in the same course
            builder.HasIndex(e => new { e.LearnerId, e.CourseId }).IsUnique();



            builder.HasOne(e => e.Learner)
                .WithMany(l => l.Enrollments)
                .HasForeignKey(e => e.LearnerId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(e => e.Status)
                   .HasConversion<string>()
                   .HasMaxLength(30)
                   .IsRequired();
        }
    }
}
