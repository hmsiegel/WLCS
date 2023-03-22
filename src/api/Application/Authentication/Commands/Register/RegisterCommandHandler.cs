namespace Application.Authentication.Commands.RegisterUser;
public sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtProvider _jwtProvider;


    public RegisterCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);

        if (emailResult.IsFailure)
        {
            return Result.Failure<AuthenticationResult>(emailResult.Errors);
        }

        Result<FirstName> firstNameResult = FirstName.Create(request.FirstName!);
        Result<LastName> lastNameResult = LastName.Create(request.LastName!);

        if (firstNameResult.IsFailure)
        {
            return Result.Failure<AuthenticationResult>(firstNameResult.Errors);
        }

        if (lastNameResult.IsFailure)
        {
            return Result.Failure<AuthenticationResult>(lastNameResult.Errors);
        }

        if (!await _userRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
        {
            return Result.Failure<AuthenticationResult>(DomainErrors.User.EmailAlreadyInUse);
        }
        var user = User.Create(
            firstNameResult.Value,
            lastNameResult.Value,
            emailResult.Value,
            request.Password!);

        _userRepository.Add(user);

        var token = await _jwtProvider.GenerateTokenAsync(user);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthenticationResult(user, token);

    }
}
