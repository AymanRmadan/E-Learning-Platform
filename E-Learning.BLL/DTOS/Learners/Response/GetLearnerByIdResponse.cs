namespace E_Learning.BLL.DTOS.Learners.Response
{
    public record GetLearnerByIdResponse
        (
        int Id,
        string FullName,
        string Email,
        string NationalId,
        string Department
        );
}
