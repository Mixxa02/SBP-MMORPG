using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORGP_Web_API.Entiteti;

namespace MMORGP_Web_API.Mapiranja
{
    public class ProizvodMapiranja : ClassMap<Proizvod>
    {
        public ProizvodMapiranja()
        {
            Table("PROIZVOD");
            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("TIP");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Rase, "RASE");
            Map(x => x.Klase, "KLASE");

            HasManyToMany(x => x.Igraci)
                .Table("KUPOVINA")
                .ParentKeyColumn("NAZIV_PROIZVODA")
                .ChildKeyColumn("ID_IGRACA")
                .Cascade.All();
                //.Inverse();
        }
    }
    class OklopMapiranja : SubclassMap<Oklop>
    {
        public OklopMapiranja()
        {
            DiscriminatorValue("OKLOP");
            Map(x => x.PoeniZaOdbranu, "ODBRAMBENI_POENI");
        }
    }
    class OruzjeMapiranja : SubclassMap<Oruzje>
    {
        public OruzjeMapiranja()
        {
            DiscriminatorValue("ORUZJE");
            Map(x => x.PoeniZaNapad, "NAPADACKI_POENI");
        }
    }
}
