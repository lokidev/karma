using KarmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaApi.Repos;
using Microsoft.Extensions.Configuration;
using KarmaApi.Services.Interfaces;

namespace KarmaApi.Services
{
    public class KarmaService : IKarmaService
    {
        private readonly IConfiguration _configuration;

        public KarmaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<Karma> GetAll()
        {
            using (var db = new KarmaContext(_configuration))
            {
                var t = new KarmaRepo(db);
                return t.GetProduts();
            }
        }
    }
}
