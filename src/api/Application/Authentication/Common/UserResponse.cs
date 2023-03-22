namespace Application.Authentication.Common;
public sealed record UserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email);
