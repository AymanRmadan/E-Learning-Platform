namespace E_Learning.BLL.DTOS.Learners.Request
{
    public record CreateLearnerRequest
    (
        string FullName,
        string Email,
        string NationalId,
        string Department
        );
}
