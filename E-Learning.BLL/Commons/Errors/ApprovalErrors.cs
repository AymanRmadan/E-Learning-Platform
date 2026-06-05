namespace E_Learning.BLL.Commons.Errors
{
    public static class ApprovalErrors
    {
        public static readonly Error EnrollmentNotFound =
            new("Approval.NotFound", "The enrollment request was not found.", StatusCodes.Status404NotFound);
        public static readonly Error InvalidStatusForDecision =
            new("Approval.InvalidStatus", "Only pending approval enrollments can be approved or rejected", StatusCodes.Status400BadRequest);
        public static readonly Error InvalidDecisionType =
            new("Approval.InvalidDecision", "Decisions can only be 'Approved' or 'Rejected'", StatusCodes.Status400BadRequest);
        public static readonly Error RejectionReasonRequired =
            new("Approval.ReasonRequired", "Rejected enrollments must have a reason", StatusCodes.Status400BadRequest);
    }
}
