using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORGP_Web_API.Entiteti;

namespace MMORGP_Web_API.Mapiranja
{
    public class PredmetMapiranja : ClassMap<Predmet>
    {
        public PredmetMapiranja() 
        {
            Table("PREDMET");
            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();
            DiscriminateSubClassesOnColumn("TIP");

            Map(x => x.Opis, "OPIS");

            HasManyToMany(x => x.Staze)
            .Table("STAZA_SADRZI_PREDMET")
            .ParentKeyColumn("NAZIV_PREDMETA")
            .ChildKeyColumn("NAZIV_STAZE")
            .Cascade.All()
            .Inverse();
        }
    }
    class KljucniPredmetMapiranja : SubclassMap<KljucniPredmet> 
    {
        public KljucniPredmetMapiranja()
        {
            Map(x => x.NadimciLikova, "NADIMCI_LIKOVA");
            DiscriminatorValue("KLJUCNI");
        }
    }
    class PredmetXPMapiranja : SubclassMap<PredmetXP>
    {
        public PredmetXPMapiranja()
        {
            Map(x => x.BonusUIskustvu, "BONUS_ISKUSTVO");
            Map(x => x.RasePremdet, "RASE");
            DiscriminatorValue("XP");
        }
    }
}
