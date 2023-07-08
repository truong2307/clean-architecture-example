namespace QuizApp.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="userAccount">User name, email, phonenumber</param>
        /// <returns></returns>
        Task<bool> ValidateUser(string userAccount, string password);
        Task<string> CreateToken();
    }
}
