namespace Presentation.Extensions;
internal static class ResultExtensions
{
    internal static async Task<IActionResult> Match(
        this Task<Result> results,
        Func<IActionResult> onSuccess,
        Func<Result, IActionResult> onFailure)
    {
        Result result = await results;

        return result.IsSuccess ? onSuccess()
            : onFailure(result);
    }

    internal static async Task<IActionResult> Match<T>(
        this Task<Result<T>> results,
        Func<T, IActionResult> onSuccess,
        Func<Result, IActionResult> onFailure)
    {
        Result<T> result = await results;
        return result.IsSuccess ? onSuccess(result.Value)
            : onFailure(result);
    }
}
