namespace SurveyBasket.Application.Abstractions.Abstractions.Const
{
    public static class Permissions
    {
        public static string Type { get; } = "Permissions";

        public const string ReadPolls = "polls:read";
        public const string AddPolls = "polls:add";
        public const string UpdatePolls = "polls:update";
        public const string DeletePolls = "polls:remove";
               
        public const string ReadQuestions = "questions:read";
        public const string AddQuestions = "questions:add";
        public const string UpdateQuestions = "questions:update";
               
        public const string ReadUser = "user:read";
        public const string AddUser = "user:add";
        public const string UpdateUser = "user:update";
               
        public const string ReadRoles = "roles:read";
        public const string AddRoles = "roles:add";
        public const string UpdateRoles = "roles:update";
               
        public const string Results = "results:read";

        public static IList<string?> GetAllPermissions()=>
            typeof(Permissions).GetFields().Select(field => field.GetValue(field) as string).ToList();

    }
}
