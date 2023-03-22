namespace Application.Authentication.Queries.GetUserByEmail;
public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
