using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Karma.Messaging.PayloadModels
{
    public class NewChildPayload
    {
        public Person parent { get; set; }
        public Person child { get; set; }
        public DateTime date { get; set; }
    }
}
