namespace E_Learning.BLL.DTOS.Learners.Request;

public record GetAllLearnerRequest
(int PageNumber = 1,
    int PageSize = 3,
    string? SearchTerm = null);