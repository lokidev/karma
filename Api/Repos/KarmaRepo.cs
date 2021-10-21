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

        public List<KarmaManagement.Models.Karma> GetProduts()
        {
            if (db != null)
            {
                List<KarmaManagement.Models.Karma> employees = new List<KarmaManagement.Models.Karma>();

                var result = db.Karmas.OrderByDescending(x => x.KarmaName).ToList();

                return result;
            }

            return null;
        }
    }
}
