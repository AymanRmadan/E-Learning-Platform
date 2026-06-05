namespace E_Learning.Domain.Entities
{
    public class Course : BaseEntity<int>
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationHours { get; set; }
        public bool RequiresApproval { get; set; } = true;
        public bool IsActive { get; set; } = true;


        public ICollection<Enrollment> Enrollments { get; set; }


    }
}
