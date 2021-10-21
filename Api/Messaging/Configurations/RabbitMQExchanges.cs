using Newtonsoft.Json;

namespace KarmaManagement.Messaging.Configurations
{
    [JsonObject("rabbit_mq_exchanges")]
    public class RabbitMQExchanges
    {
        [JsonProperty("peopleExchange")]
        public string PeopleExchange { get; set; }
        [JsonProperty("worldExchange")]
        public string WorldExchange { get; set; }
    }
}
