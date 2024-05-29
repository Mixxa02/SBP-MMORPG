using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORGP_Web_API.Mapiranja
{
    public class KupovinaMapiranja : ClassMap<MMORGP_Web_API.Entiteti.Kupovina>
    {
        public KupovinaMapiranja()
        {
            Table("KUPOVINA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV_PROIZVODA");
            Map(x => x.Igrac, "ID_IGRACA");
        }
    }
}
