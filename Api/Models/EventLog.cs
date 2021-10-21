using System;
using System.Collections.Generic;

#nullable disable

namespace KarmaManagement.Models
{
    public partial class EventLog
    {
        public int Id { get; set; }
        public string ObjectType { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public DateTime WorldDate { get; set; }
        public DateTime RealDate { get; set; }
    }
}
