namespace Application.Authentication.Commands.RegisterUser;
public sealed record RegisterCommand(
    string? FirstName,
    string? LastName,
    string? Email,
    string? Password) : ICommand<AuthenticationResult>;
