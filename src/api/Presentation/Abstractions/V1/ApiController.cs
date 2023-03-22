namespace Presentation.Abstractions.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[ApiController]
public class ApiController : ControllerBase
{
    protected readonly ISender Sender;
    protected readonly IMapper Mapper;

    protected ApiController(
        ISender sender,
        IMapper mapper)
    {
        Sender = sender;
        Mapper = mapper;
    }

    protected IActionResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            _ => BadRequest(CreateProblemDetails(
                "Bad Request",
                "Bad Request",
                "One of more errors occurred",
                StatusCodes.Status400BadRequest,
                result.Errors))
        };
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        string detail,
        string type,
        int statusCode,
        Error[]? errors = null)
    {
        return new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Type = type,
            Status = statusCode,
            Extensions = { { nameof(errors), errors } }
        };
    }
}
