namespace Application.Authentication.Commands.Login;
internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);

        User? user = await _userRepository.GetByEmailAsync(emailResult.Value, cancellationToken);

        if (user is null)
        {
            return Result.Failure<AuthenticationResult>(DomainErrors.User.InvalidCredentials);
        }

        if (user.Password != request.Password)
        {
            return Result.Failure<AuthenticationResult>(DomainErrors.User.InvalidCredentials);
        }

        var token = await _jwtProvider.GenerateTokenAsync(user);

        return new AuthenticationResult(user, token);
    }
}
