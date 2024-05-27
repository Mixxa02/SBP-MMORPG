using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;

namespace MMORPG.Mapiranja
{
    public class SesijaMapiranja : ClassMap<Sesija>
    {
        public SesijaMapiranja() 
        {
            Table("SESIJA");

            Id(x => x.Id, "ID").GeneratedBy.Assigned();

            Map(x => x.VremePovezivanjaNaServer, "VREME_POVEZIVANJA");
            Map(x => x.VremeUcestvovanja, "DUZINA_SESIJE");
            Map(x => x.ZaradjeniGold, "ZARADJENO_ZLATO");
            Map(x => x.ZaradjeniXPpoeni, "ZARADJENI_XP");

            References(x => x.Igrac).Column("ID_IGRACA").LazyLoad();

        }
    }
}