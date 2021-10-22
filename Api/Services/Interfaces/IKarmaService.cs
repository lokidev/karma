using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaManagement.Services.Interfaces
{
  public interface IKarmaService
  {
    ICollection<Karma> GetAll();
    EventLog LogMessage(EventLog eventLog);
    List<EventLog> GetLogs(string objectType, string messageType, DateTime? currDateTime);
    bool StartClock();
    bool StopClock();
  }
}
