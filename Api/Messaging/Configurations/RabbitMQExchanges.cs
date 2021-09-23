using Newtonsoft.Json;

namespace KarmaApi.Messaging.Configurations
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
