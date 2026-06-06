namespace E_Learning.BLL.DTOS.Courses.Response
{
    public class GetAllCoursesResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DurationHours { get; set; }
        public bool RequiresApproval { get; set; }
        public bool IsActive { get; set; }
    }
}
