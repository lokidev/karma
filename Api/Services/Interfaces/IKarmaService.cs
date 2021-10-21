using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaManagement.Services.Interfaces
{
    public interface IKarmaService
    {
        public ICollection<KarmaManagement.Models.Karma> GetAll();
        public bool StartClock();
        public bool StopClock();
    }
}
