using Microsoft.AspNetCore.Components;

namespace Presentation.Controllers.V1;
public sealed class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [HttpPost(ApiRoutes.Authentication.Login)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        return await Result
            .Create(
            Mapper.Map<LoginCommand>(request))
            .Bind(command => Sender.Send(command, cancellationToken))
            .Match(
            id => CreatedAtAction(
                nameof(GetUserById),
                new { id },
                id),
            HandleFailure);
    }

    [HttpPost(ApiRoutes.Authentication.Register)]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<RegisterCommand>(request);
        var registerResult = await Sender.Send(command, cancellationToken);

        if (registerResult.IsFailure)
        {
            return HandleFailure(registerResult);
        }

        return Ok(registerResult.Value);
        //return await Result
        //    .Create(
        //    Mapper.Map<RegisterCommand>(request))
        //    .Bind(command => Sender.Send(command, cancellationToken))
        //    .Match(
        //    id => CreatedAtAction(
        //        nameof(GetUserById),
        //        new { id },
        //        id),
        //    HandleFailure);
    }

    [HttpGet(ApiRoutes.Authentication.GetById)]
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);

        Result<UserResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Value);
    }

    [HttpGet(ApiRoutes.Authentication.GetByEmail)]
    public async Task<IActionResult> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        var query = new GetUserByEmailQuery(email);

        Result<UserResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Value);
    }

}
