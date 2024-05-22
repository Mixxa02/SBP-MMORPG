using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;


namespace MMORPG.Mapiranja
{
    public class StazaMapiranja : ClassMap<Staza>
    {
        public StazaMapiranja() 
        {
            Table("STAZA");
            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();
            DiscriminateSubClassesOnColumn("TIP");

            Map(x => x.BonusPoeni, "BONUS_POENI");
            Map(x => x.Potrebne_Klase, "POTREBNE_KLASE");
            Map(x => x.Potrebne_Rase, "POTREBNE_RASE");

            HasManyToMany(x => x.Predmeti)
            .Table("STAZA_SADRZI_PREDMET")
            .ParentKeyColumn("NAZIV_STAZE")
            .ChildKeyColumn("NAZIV_PREDMETA")
            .Cascade.All();
            //.Inverse();
        }
    }
    class StazaZaIgracaMapiranja : SubclassMap<StazaZaIgraca>
    {
        public StazaZaIgracaMapiranja()
        {
            DiscriminatorValue("IGRAC");
            Map(x => x.BrIgranjaStaze, "BR_IGRANJA");
            Map(x => x.BrUbijenihNeprijatelja, "BROJ_SAVLADANIH_NEPRIJATELJA");
            //HasOne(x => x.Igrac).Cascade.All();
        }
    }
    class StazaZaTimaMapiranja : SubclassMap<StazaZaTim>
    {
        public StazaZaTimaMapiranja()
        {
            DiscriminatorValue("TIM");
            References(x => x.Tim, "STAZA_ZA_TIM").Unique();
        }
    }
}
