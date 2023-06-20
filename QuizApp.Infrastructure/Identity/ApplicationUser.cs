using Microsoft.AspNetCore.Identity;

namespace QuizApp.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
    }
}
