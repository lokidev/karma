using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaManagement.Models.Requests
{
  public class LogsRequestModel
  {
    public string objectType { get; set; }
    public string messageType { get; set; }
    public DateTime? currDateTime { get; set; }
  }
}
