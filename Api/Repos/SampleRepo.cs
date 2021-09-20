using KarmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KarmaApi.Repos
{
    public class KarmaRepo
    {
        private KarmaContext db;

        public KarmaRepo(KarmaContext db)
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
    }
}
