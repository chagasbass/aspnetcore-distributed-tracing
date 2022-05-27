using WorkerServiceUm.Entidades;
using WorkerServiceUm.Serviços;

namespace WorkerServiceUm
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
            var contador = 0;
            var workerName = "WorkerServiceUM";

            while (!stoppingToken.IsCancellationRequested)
            {
                contador++;
                var nomeProduto = $"Produto - {contador}";
                var produto = new Produto(nomeProduto);

                await _produtoService.EnviarProduto(produto);

                _logger.LogInformation("Envio de produto efetuado em : {time}", DateTimeOffset.Now);

                _dataService.StartActivitySource(workerName, produto, Guid.NewGuid());

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}