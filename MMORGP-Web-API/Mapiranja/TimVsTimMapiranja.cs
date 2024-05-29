using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORGP_Web_API.Mapiranja
{
    public class TimVsTimMapiranja : ClassMap<MMORGP_Web_API.Entiteti.TimVsTim>
    {
        public TimVsTimMapiranja()
        {
            Table("BORBA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Pobednik, "POBEDNIK");
            //References(x => x.Tim1).Column("NAZIV_PRVOG_TIMA").LazyLoad();
            Map(x => x.Tim1, "NAZIV_PRVOG_TIMA");
            //References(x => x.Tim2).Column("NAZIV_DRUGOG_TIMA").LazyLoad();
            Map(x => x.Tim2, "NAZIV_DRUGOG_TIMA");
            Map(x => x.Vreme, "VREME");
            Map(x => x.Bonus, "BONUS");

        }
    }
}
