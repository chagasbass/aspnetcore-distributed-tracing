namespace MinimalApi.Shared
{
    public class BaseConfigurationOptions
    {
        public const string BaseConfig = "BaseConfiguration";
        public string? NomeAplicacao { get; set; }
        public string? Descricao { get; set; }
        public string? NomeDesenvolvedor { get; set; }
        public string? URlConsumo { get; set; }

        public BaseConfigurationOptions() { }

    }
}
