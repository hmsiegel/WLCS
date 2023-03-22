namespace Application.Authentication.Commands.RegisterUser;
internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(DomainErrors.FirstName.Empty.Message)
            .MaximumLength(FirstName.MaxLength).WithMessage(DomainErrors.FirstName.Length);
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(DomainErrors.LastName.Empty.Message)
            .MaximumLength(LastName.MaxLength).WithMessage(DomainErrors.LastName.Length.Message);
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(DomainErrors.Email.Empty.Message)
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage(DomainErrors.Email.Invalid.Message);
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(DomainErrors.Password.Empty.Message)
            .MinimumLength(8).WithMessage(DomainErrors.Password.Length)
            .Matches(@"[A-Z]+").WithMessage(DomainErrors.Password.Uppercase.Message)
            .Matches(@"[a-z]+").WithMessage(DomainErrors.Password.Lowercase.Message)
            .Matches(@"[0-9]+").WithMessage(DomainErrors.Password.Number.Message)
            .Matches(@"[\!\@\$\%\^\&\*\`\|\~\<\>\,\.\[\]\{\}]")
            .WithMessage(DomainErrors.Password.Symbols.Message);
    }
}
