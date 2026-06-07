namespace E_Learning.BLL.DTOS.Learners.Request;

public record GetAllLearnerRequest
(int PageNumber = 1,
    int PageSize = 10,
    string? SearchTerm = null);