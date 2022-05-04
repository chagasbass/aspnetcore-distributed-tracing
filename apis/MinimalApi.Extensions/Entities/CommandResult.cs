namespace MinimalApi.Extensions.Entities
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CommandResult() { }

        public CommandResult(object data, bool sucess = false, string message = "")
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
