namespace MinimalApi.Extensions.Shared
{
    public class JaegerConfigurationOptions
    {
        public const string JaegerConfig = "JaegerConfiguration";

        public string? AgentHost { get; set; }
        public string? AgentPort { get; set; }

        public JaegerConfigurationOptions() { }

    }
}
