namespace SurveyBasket.Application.Abstractions.Abstractions.Const
{
    public static class Permissions
    {
        public static string Type { get; } = "Permissions";

        public static string ReadPolls = "polls:read";
        public static string AddPolls = "polls:add";
        public static string UpdatePolls = "polls:update";
        public static string DeletePolls = "polls:remove";

        public static string ReadQuestions = "questions:read";
        public static string AddQuestions = "questions:add";
        public static string UpdateQuestions = "questions:update";

        public static string ReadUser = "user:read";
        public static string AddUser = "user:add";
        public static string UpdateUser = "user:update";

        public static string ReadRoles = "roles:read";
        public static string AddRoles = "roles:add";
        public static string UpdateRoles = "roles:update";

        public static string Results = "results:read";



    }
}
