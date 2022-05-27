using Confluent.Kafka;
using System.Text.Json;
using WorkerServiceUm.Entidades;

namespace WorkerServiceUm.Serviços
{
    public class ProdutoService
    {
        public Produto ReceberProduto()
        {
            var server = "kafka-0.restoque.com.br:9094";
            var testeTopic = "teste-topic";

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = server,
                GroupId = "worker-app",
                SessionTimeoutMs = 6000,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumerBuilder = new ConsumerBuilder<Null, string>(consumerConfig).Build();
            consumerBuilder.Subscribe(testeTopic);

            var consumer = consumerBuilder.Consume(5000);

            if (consumer is not null)
            {
                var produtoEvent = JsonSerializer.Deserialize<Produto>(consumer.Message.Value);
                return produtoEvent;
            }

            return default;
        }
    }
}
