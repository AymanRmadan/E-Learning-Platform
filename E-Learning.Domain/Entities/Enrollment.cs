
namespace E_Learning.Domain.Entities;

public class Enrollment : BaseEntity<int>
{
    public int LearnerId { get; set; }
    public Learner Learner { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }


    public DateOnly EnrollmentDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.PendingApproval;


    public DateOnly? DecisionDate { get; set; }
    public string? RejectionReason { get; set; }

}

