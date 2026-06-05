using E_Learning.Domain.Entities.Auths;

namespace E_Learning.Domain.Entities;

public class Learner : BaseEntity<int>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string NationalId { get; set; }
    public string Department { get; set; }


    public ICollection<Enrollment> Enrollments { get; set; }

    public int? UserId { get; set; }
    public ApplicationUser? User { get; set; }

}
