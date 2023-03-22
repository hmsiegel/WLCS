namespace Domain.Errors;
public static class DomainErrors
{
    public static class Email
    {
        public static readonly Error Empty = new(
                    "Email.Empty",
                    "Email cannot be empty");

        public static readonly Error Invalid = new(
                "Email.Invalid",
                "Email is invalid.");

        public static readonly Error TooLong = new(
                "Email.TooLong",
                "The email is too long.");
    }

    public static class FirstName
    {
        public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name cannot be empty.");

        public static readonly Error Length = new(
            "FirstName.Length",
            "The first name cannot be longer than 50 characters.");
    }

    public static class LastName
    {
        public static readonly Error Empty = new(
            "LastName.Empty",
            "Last name cannot be empty.");

        public static readonly Error Length = new(
            "LastName.Length",
            "The last name cannot be longer than 50 characters.");
    }

    public static class User
    {
        public static readonly Func<Guid, Error> NotFound = id => new(
                "User.NotFound",
                $"The user with the identifier {id} was not found.");

        public static readonly Func<string, Error> EmailNotFound = email => new(
                "User.EmailNotFound",
                $"The user with the email {email} was not found.");

        public static readonly Error EmailAlreadyInUse = new(
            "User.EmailAlreadyInUse",
            "Email already in use.");

        public static readonly Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "Inavlid credentials entered.");
    }

    public static class Password
    {
        public static readonly Error Empty = new(
            "Password.Empty",
            "Password cannot be empty.");

        public static readonly Error TooShort = new(
            "Password.TooShort",
            "Password must be at least 8 characters long.");

        public static readonly Error Uppercase = new(
            "Password.Uppercase",
            "Your password must contain at least one uppercase letter.");

        public static readonly Error Lowercase = new(
            "Password.Lowercase",
            "Your password must contain at least one lowercase letter.");

        public static readonly Error Number = new(
            "Password.Number",
            "Your password must contain at least one number.");

        public static readonly Error Symbols = new(
            "Password.Symbols",
            @"Your password must contain at least one of the following symbols: ( !@$%^&*`|~<>,.[]{} ).");

        public static readonly Error Length = new(
            "Password.Length",
            "Your password must be at least 8 characters long.");
    }
}
