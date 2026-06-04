
namespace E_Learning.Domain.Entities;

public class Enrollment : BaseEntity<int>
{
    public int LearnerId { get; set; }
    public Learner Learner { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }


    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.PendingApproval;


    public DateTime? DecisionDate { get; set; }
    public string? RejectionReason { get; set; } // سبب الرفض في حال وجد

}

