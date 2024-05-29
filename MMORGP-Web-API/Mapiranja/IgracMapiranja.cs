using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORGP_Web_API.Mapiranja
{
    public class IgracMapiranja : ClassMap<MMORGP_Web_API.Entiteti.Igrac>
    {
        public IgracMapiranja()
        {
            Table("IGRAC");

            Id(x => x.Id, "ID").GeneratedBy.Increment();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");
            Map(x => x.Nadimak, "NADIMAK");
            Map(x => x.Lozinka, "LOZINKA");
            Map(x => x.Uzrast, "UZRAST");

            References(x => x.Tim).Column("NAZIV_TIMA").LazyLoad();

            HasMany(x=>x.Pomocnici).KeyColumn("ID_IGRACA").Cascade.All().Inverse();

            References(x => x.Lik).Column("ID_LIKA").LazyLoad();


            HasManyToMany(x => x.Proizvodi)
                .Table("KUPOVINA")
                .ParentKeyColumn("ID_IGRACA")
                .ChildKeyColumn("NAZIV_PROIZVODA")
                .Cascade.All()
                .Inverse();
        }
    }
}
