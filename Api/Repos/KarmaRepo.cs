using KarmaManagement.Repos.Interfaces;
using KarmaManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KarmaManagement.Repos
{
    public class KarmaRepo: IKarmaRepo
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
    }
}
