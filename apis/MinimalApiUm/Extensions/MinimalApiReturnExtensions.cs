using MinimalApi.Extensions.Entities;

namespace MinimalApiUm.Extensions
{
    public static class MinimalApiReturnExtensions
    {
        public static IResult FormatApiResponse(CommandResult commandResult, string endpointUrl = "")
        {
            if (!commandResult.Success)
                return Results.BadRequest(commandResult);
            else
                return Results.Created(endpointUrl, commandResult);
        }
    }
}
