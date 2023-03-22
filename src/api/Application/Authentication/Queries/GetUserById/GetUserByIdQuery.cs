namespace Application.Authentication.Queries.GetUserById;
public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
