namespace MinimalApi.Extensions.Shared
{
    public class JaeggerConfigurationOptions
    {
        public const string JaeggerConfig = "JaeggerConfiguration";

        public string? AgentHost { get; set; }
        public string? AgentPort { get; set; }

        public JaeggerConfigurationOptions() { }

    }
}
