namespace E_Learning.BLL.DTOS.Passwords.Requests;
public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword
    );


