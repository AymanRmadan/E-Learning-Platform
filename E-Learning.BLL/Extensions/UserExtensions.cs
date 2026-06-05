namespace E_Learning.BLL
{
    public static class UserExtensions
    {
        //public static string? GetUserId(this ClaimsPrincipal user) =>
        //    user.FindFirstValue(ClaimTypes.NameIdentifier);

        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userId, out var id) ? id : 0;
        }

    }
}
