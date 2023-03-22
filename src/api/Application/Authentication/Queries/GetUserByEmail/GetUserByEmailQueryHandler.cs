namespace Application.Authentication.Queries.GetUserByEmail;
internal sealed class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);

        var user = await _userRepository.GetByEmailAsync(emailResult.Value, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(DomainErrors.User.EmailNotFound(request.Email));
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
