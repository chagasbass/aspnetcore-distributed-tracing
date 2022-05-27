using WorkerServiceUm.Serviços;

namespace WorkerServiceDois
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private ProdutoService _produtoService;
        private DataService _dataService;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _produtoService = new ProdutoService();
            _dataService = new DataService();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var activity = _dataService.StartActivitySource("WorkerServiceDois");

                var produto = _produtoService.ReceberProduto();

                if (produto is not null)
                {
                    _logger.LogInformation("Recebimento de produto efetuado em : {time} {produto}", DateTimeOffset.Now, produto.Nome);

                    _dataService.AddActivityData(activity, produto);
                }
                else
                {
                    _logger.LogInformation("Nada para processamento");
                }

                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}