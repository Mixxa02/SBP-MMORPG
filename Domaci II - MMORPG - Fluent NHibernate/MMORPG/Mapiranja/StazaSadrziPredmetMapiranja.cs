using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Mapiranja
{
    public class StazaSadrziPredmetMapiranja : ClassMap<MMORPG.Entiteti.StazaSadrziPredmet>
    {
        public StazaSadrziPredmetMapiranja()
        {
            Table("STAZA_SADRZI_PREDMET");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.NazivPredmeta, "NAZIV_PREDMETA");
            Map(x => x.NazivStaze, "NAZIV_STAZE");
        }
    }
}
