using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaManagement.Repos.Interfaces
{
  interface IKarmaRepo
  {
    List<Karma> GetProduts();
    EventLog LogMessage(EventLog eventLog);
    List<EventLog> GetLogs(string objectType, string messageType, DateTime? currDateTime);
    int GetLogsCount(string objectType, string messageType, DateTime? currDateTime);
  }
}
