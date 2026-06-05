namespace E_Learning.BLL.DTOS.Learners.Request
{
    public record UpdateLearnerRequest
    (
        string FullName,
        string Email,
        string NationalId,
        string Department
        );
}
