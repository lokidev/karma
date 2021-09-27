using KarmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaApi.Repos;
using Microsoft.Extensions.Configuration;
using KarmaApi.Services.Interfaces;
using KarmaApi.Messaging.Interfaces;

namespace KarmaApi.Services
{
    public class KarmaService : IKarmaService
    {
        private readonly IConfiguration _configuration;
        private IRabbitMqService mRabbitMqService;

        public KarmaService(IConfiguration configuration, IRabbitMqService rabbitMqService)
        {
            _configuration = configuration;
            mRabbitMqService = rabbitMqService;
        }

        public ICollection<KarmaApi.Models.Karma> GetAll()
        {
            using (var db = new KarmaContext(_configuration))
            {
                var t = new KarmaRepo(db);
                return t.GetProduts();
            }
        }

        public bool StartClock()
        {
            mRabbitMqService.sendMessage(DateTime.Now, "karma_exchange_main.clock.start", true);
            return true;
        }

        public bool StopClock()
        {
            mRabbitMqService.sendMessage(DateTime.Now, "karma_exchange_main.clock.stop", true);
            return true;
        }
    }
}
