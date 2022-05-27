using Confluent.Kafka;
using System.Text.Json;
using WorkerServiceUm.Entidades;

namespace WorkerServiceUm.Serviços
{
    public class ProdutoService
    {
        public async Task EnviarProduto(Produto produto)
        {
            var server = "kafka-0.restoque.com.br:9094";
            var testeTopic = "teste-topic";

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = server
            };

            var message = JsonSerializer.Serialize(produto);

            using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            await producer.ProduceAsync(testeTopic, new Message<Null, string>
            {
                Value = message
            });

            Console.WriteLine("Evento gerado");
        }
    }
}
