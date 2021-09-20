using KarmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaApi.Services
{
    public interface IKarmaService
    {
        public ICollection<Karma> GetAll();
    }
}
