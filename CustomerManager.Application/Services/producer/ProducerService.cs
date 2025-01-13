using Confluent.Kafka;

namespace CustomerManagement.WebApi.producer
{
    public class ProducerService
    {
        private readonly IProducer<string, string> _producer;

        public ProducerService()
        {
            _producer = new ProducerBuilder<string, string>(KafkaProducerConfig.GetConfig()).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            var kafkamessage = new Message<string, string> {Key="eli", Value = message, };

            //var topicPart = new TopicPartition(topic, new Partition(3));

            await _producer.ProduceAsync(/*topicPart*/ topic, kafkamessage);
        }
    }
}
