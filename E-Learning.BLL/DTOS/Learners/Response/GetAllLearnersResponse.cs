namespace E_Learning.BLL.DTOS.Learners.Response
{
    //public record GetAllLearnersResponse
    //    (
    //    int Id,
    //    string FullName,
    //    string Email,
    //    string NationalId,
    //    string Department
    //    );

    public class GetAllLearnersResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string Department { get; set; }
    }
}
