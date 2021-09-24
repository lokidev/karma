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

        public List<KarmaApi.Models.Karma> GetProduts()
        {
            if (db != null)
            {
                List<KarmaApi.Models.Karma> employees = new List<KarmaApi.Models.Karma>();

                var result = db.Karmas.OrderByDescending(x => x.KarmaName).ToList();

                return result;
            }

            return null;
        }
    }
}
