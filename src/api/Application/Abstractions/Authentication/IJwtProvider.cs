namespace Application.Abstractions.Authentication;
public interface IJwtProvider
{
    Task<string> GenerateTokenAsync(User user);
}
