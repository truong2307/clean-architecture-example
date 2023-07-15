namespace QuizApp.Infrastructure.Common.Constants
{
    public class Identity
    {
        public class Role
        {
            public const string ADMIN_ROLE = "Admin";
            public const string USER_ROLE = "User";
            public const string MANAGER_ROLE = "Teacher";
        }

        public static class ClaimTypeUser
        {
            public const string USER_NAME = "name";
            public const string USER_ID = "userId";
            public const string ROLE = "role";
            public const string NICK_NAME = "nickName";
            public const string FULL_NAME = "fullName";
        }
    }
}
