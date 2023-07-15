using QuizApp.Application.Common.Interfaces;
using QuizApp.Infrastructure.Common.Constants;
using System.Security.Claims;

namespace QuizApp.API.Services
{
    public class ClaimUserServices : IClaimUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimUserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserName() => _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;

        public string GetCurrentUserId() => _httpContextAccessor.HttpContext.User?.FindFirst(Identity.ClaimTypeUser.USER_ID)?.Value;

        public string GetCurrentUserRole() => _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
    }
}
