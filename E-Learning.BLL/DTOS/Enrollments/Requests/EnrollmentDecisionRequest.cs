namespace E_Learning.BLL.DTOS.Enrollments.Request
{
    public record EnrollmentDecisionRequest(
        string Decision,
        string? Reason
    );
}