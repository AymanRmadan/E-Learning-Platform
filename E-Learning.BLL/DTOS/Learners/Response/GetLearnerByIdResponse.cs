namespace E_Learning.BLL.DTOS.Learners.Response
{

    public class GetLearnerByIdResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string Department { get; set; }
    }
}
