namespace Infrastructure.Authentication;
public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IPermissionService _permissionService;

    public JwtProvider(
        IOptions<JwtOptions> jwtOptions,
        IDateTimeProvider dateTimeProvider,
        IPermissionService permissionService)
    {
        _jwtOptions = jwtOptions.Value;
        _dateTimeProvider = dateTimeProvider;
        _permissionService = permissionService;
    }

    public async Task<string> GenerateTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id!.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName!.Value),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName!.Value),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email!.Value!),
        };

        //HashSet<string> permissions = await _permissionService
        //    .GetPermissionsAsync(user.Id.Value!);

        //foreach (var permission in permissions)
        //{
        //    claims.Add(new(CustomClaims._permission, permission));
        //}

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey!)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        await Task.CompletedTask;

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
