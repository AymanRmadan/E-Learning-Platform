using E_Learning.Domain.Entities.Auths;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Domain.Entities;

public class Learner : BaseEntity<int>
{

    public string FullName { get; set; }
    public string Email { get; set; }
    public string NationalId { get; set; }
    public string Department { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public ICollection<Enrollment> Enrollments { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public ApplicationUser? User { get; set; }

}
