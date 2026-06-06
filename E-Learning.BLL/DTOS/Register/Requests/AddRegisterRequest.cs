namespace E_Learning.BLL.DTOS.Register.Requests
{
    public record AddRegisterRequest(
        string Email,
        string Password,
        string Name,
         string NationalId,
        string Department
        );
}
