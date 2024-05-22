using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;

namespace MMORPG.Mapiranja
{
    public class LikMapiranja : ClassMap<Lik>
    {
        public LikMapiranja()
        {
            Table("LIK");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            DiscriminateSubClassesOnColumn("TIP_KLASE");

            Map(x => x.KolicinaZlata, "KOLICINA_ZLATA");
            Map(x => x.Iskustvo, "ISKUSTVO");
            Map(x => x.StepenZamora, "STEPEN_ZAMORA");
            Map(x => x.NivoZdravstvenogStanja, "NIVO_ZDRAVLJA");

            Map(x => x.FCovek, "FCOVEK");
            Map(x => x.FPatuljak, "FPATULJAK");
            Map(x => x.FOrk, "FORK");
            Map(x => x.FDemon, "FDEMON");
            Map(x => x.FVilenjak, "FVILENJAK");

            Map(x => x.UmesnostSkrivanja, "UMESNOST_SKRIVANJA");
            Map(x => x.TipOruzja, "TIP_ORUZJA");
            Map(x => x.EnergijaZaMagiju, "ENERGIJA_ZA_MAGIJU");

            //References(x => x.Igrac).Column("ID_IGRACA").Unique();

        }
    }
    class LopovMapiranja : SubclassMap<Lopov>
    {
        public LopovMapiranja() 
        {
            DiscriminatorValue("lopov");
            Map(x => x.MaxNivoZamki, "MAX_NIVO_ZAMKI");
            Map(x => x.NivoBuke, "NIVO_BUKE");
        }
    }
    class SvestenikMapiranja : SubclassMap<Svestenik>
    {
        public SvestenikMapiranja()
        {
            DiscriminatorValue("svestenik");
            Map(x => x.TipBlagoslova, "TIP_BLAGOSLOVA");
            Map(x => x.TipReligije, "TIP_RELIGIJE");
            Map(x => x.MogucnostLecenja, "MOGUCNOST_LECENJA");
        }
    }
    class StrelacMapiranja : SubclassMap<Strelac>
    {
        public StrelacMapiranja()
        {
            DiscriminatorValue("strelac");
            Map(x => x.LukIliSamostrel, "LUK_ILI_SAMOSTREL");
        }
    }
    class OklopnikMapiranja : SubclassMap<Oklopnik>
    {
        public OklopnikMapiranja()
        {
            DiscriminatorValue("oklopnik");
            Map(x => x.MaxTezinaOklopa, "MAX_TEZINA_OKLOPA");
        }
    }
    class BoracMapiranja : SubclassMap<Borac>
    {
        public BoracMapiranja()
        {
            DiscriminatorValue("borac");
            Map(x => x.OruzjeUObeRuke, "ORUZJE_U_OBE_RUKE");
            Map(x => x.KoristiStit, "KORISTI_STIT");
        }
    }
    class CarobnjakMapiranja : SubclassMap<Carobnjak>
    {
        public CarobnjakMapiranja()
        {
            DiscriminatorValue("carobnjak");
            Map(x => x.SpisakMagija, "SPISAK_MAGIJA");
        }
    }
}
