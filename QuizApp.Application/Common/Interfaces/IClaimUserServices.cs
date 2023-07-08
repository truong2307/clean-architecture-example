namespace QuizApp.Application.Common.Interfaces
{
    public interface IClaimUserServices
    {
        string GetCurrentUserId();
        string GetCurrentUserRole();
        string GetCurrentUserName();
    }
}
