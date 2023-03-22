namespace Presentation.Common;
public static class ApiRoutes
{
    public const string BaseRoute = "v{version:apiVersion}";

    public static class Authentication
    {
        public const string Login = "login";
        public const string Register = "register";
        public const string GetById = "auth/{id:guid}";
        public const string GetByEmail = "auth/email";
    }
}
