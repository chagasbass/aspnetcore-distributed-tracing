using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.Entities
{
    public class CommandResult : ICommandResult
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        public CommandResult() { }

        public CommandResult(object data, bool sucess = false, string? message = "")
        {
            Success = sucess;
            Message = message;
            Data = data;
        }

        public CommandResult(bool sucess, string message)
        {
            Success = sucess;
            Message = message;
        }
    }
}
