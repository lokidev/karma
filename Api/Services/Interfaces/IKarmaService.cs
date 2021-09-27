using KarmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaApi.Models;

namespace KarmaApi.Services.Interfaces
{
    public interface IKarmaService
    {
        public ICollection<KarmaApi.Models.Karma> GetAll();
        public bool StartClock();
        public bool StopClock();
    }
}
