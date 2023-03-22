namespace Infrastructure.Authentication.Options;
public class JwtOptions
{
    public const string? SectionName = "JwtSettings";
    public string? SecurityKey { get; init; } = string.Empty;
    public string? Issuer { get; init; } = string.Empty;
    public string? Audience { get; init; } = string.Empty;
    public int ExpirationMinutes { get; init; } 
}
