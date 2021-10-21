using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaManagement.Repos.Interfaces
{
    interface IKarmaRepo
    {
        List<KarmaManagement.Models.Karma> GetProduts();
    }
}
