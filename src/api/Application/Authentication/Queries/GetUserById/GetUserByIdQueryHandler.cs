namespace Application.Authentication.Queries.GetUserById;
internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(DomainErrors.User.NotFound(request.UserId));
        }

        var response = new UserResponse
        (
            user.Id!.Value,
            user.FirstName!.Value,
            user.LastName!.Value,
            user.Email!.Value!
        );

        return response;
    }
}
