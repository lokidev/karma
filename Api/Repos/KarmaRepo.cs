using KarmaManagement.Repos.Interfaces;
using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KarmaManagement.Repos
{
    public class KarmaRepo : IKarmaRepo
    {
        private KarmaManagementContext db;

        public KarmaRepo(KarmaManagementContext db)
        {
            this.db = db;
        }

        public List<Karma> GetProduts()
        {
            if (db != null)
            {
                List<Karma> employees = new List<Karma>();

                var result = db.Karmas.OrderByDescending(x => x.KarmaName).ToList();

                return result;
            }

            return null;
        }

        public EventLog LogMessage(EventLog eventLog)
        {
            if (db != null)
            {

                var result = db.EventLogs.Add(eventLog);
                db.SaveChanges();
                return result.Entity;
            }

            return null;
        }

        public List<EventLog> GetLogs(string objectType, string messageType, DateTime? currDateTime)
        {
            var result = new List<EventLog>();
            if (!currDateTime.HasValue)
            {
                result = db.EventLogs.Where(x => x.ObjectType == objectType && x.MessageType == messageType).ToList();
            }
            else
            {
                result = db.EventLogs.Where(x => x.ObjectType == objectType && x.MessageType == messageType && x.WorldDate.HasValue)
                  .Where(f => f.WorldDate.Value.Year == currDateTime.Value.Year).ToList();
            }
            return result;
        }

        public int GetLogsCount(string objectType, string messageType, DateTime? currDateTime)
        {
            var result = 0;
            if (!currDateTime.HasValue)
            {
                result = db.EventLogs.Where(x => x.ObjectType == objectType && x.MessageType == messageType).ToList().Count();
            }
            else
            {
                result = db.EventLogs.Where(x => x.ObjectType == objectType && x.MessageType == messageType && x.WorldDate.HasValue)
                  .Where(f => f.WorldDate.Value.Year == currDateTime.Value.Year).ToList().Count();
            }
            return result;
        }
    }
}
