using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaManagement.Repos;
using Microsoft.Extensions.Configuration;
using KarmaManagement.Services.Interfaces;
using KarmaManagement.Messaging.Interfaces;

namespace KarmaManagement.Services
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

        public ICollection<KarmaManagement.Models.Karma> GetAll()
        {
            using (var db = new KarmaManagementContext(_configuration))
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
