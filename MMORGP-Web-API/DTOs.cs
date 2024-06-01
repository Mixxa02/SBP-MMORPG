using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMORGP_Web_API.Entiteti;

namespace MMORGP_Web_API
{
    #region Igrac
    public class IgracPregled
    {
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Nadimak { get; set; }
        public int Uzrast {  get; set; }
        public IgracPregled() { }
        public IgracPregled(string id, string ime, string prezime,
            string nadimak, int uzrast)
        {
            this.ID = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Nadimak = nadimak;
            this.Uzrast = uzrast;
        }
    }

    public class IgracBasic
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Nadimak { get; set; }
        public string Lozinka { get; set; }
        public char Pol {  get; set; }
        public int Uzrast { get; set; }
        public Tim Tim { get; set; }
        public Lik Lik { get; set; }
        public virtual IList<Sesija> Sesije { get; set; }
        public virtual IList<Pomocnik> Pomocnici { get; set; }
        public virtual IList<Proizvod> Proizvodi { get; set; }


        public IgracBasic()
        {
            Sesije = new List<Sesija>();
            Pomocnici = new List<Pomocnik>();
            Proizvodi = new List<Proizvod>();
        }
        public IgracBasic(int id, string ime, string prezime, string nadimak, string lozinka, char pol, int uzrast)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Nadimak = nadimak;
            this.Lozinka = lozinka;
            this.Pol = pol;
            this.Uzrast = uzrast;
        }
    }
    #endregion
    #region Tim
    public class TimPregled
    {
        public string Naziv {  get; set; }
        public int Plasman { get; set; }
        public int BonusPoeni { get; set; }
        public int Max {  get; set; }
        public int Min { get; set; }
        public TimPregled() { }
        public TimPregled(string naziv, int plasman, int bonusPoeni, int max, int min)
        {
            this.Naziv = naziv;
            this.Plasman = plasman;
            this.BonusPoeni = bonusPoeni;
            this.Max = max;
            this.Min = min;
        }
    }
    public class TimBasic
    {
        public string Naziv { get; set; }
        public int Plasman { get; set; }
        public int BonusPoeni { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public StazaZaTim StazaZaTim;
        public TimBasic()
        {
            this.Igraci = new List<Igrac>();
        }
        public TimBasic(string naziv, int plasman, int bonusPoeni, int max, int min, StazaZaTim stazaZaTim)
        {
            Naziv = naziv;
            Plasman = plasman;
            BonusPoeni = bonusPoeni;
            Max = max;
            Min = min;
        }
    }
    #endregion
    #region Predmet
    public class PredmetPregled
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public PredmetPregled() { }
        public PredmetPregled(string naziv, string opis)
        {
            this.Naziv = naziv;
            this.Opis = opis;
        }
    }
    public class KljucniPredmetPregled : PredmetPregled
    {
        public string NadimciLikova { get; set; }
        public KljucniPredmetPregled() { }
        public KljucniPredmetPregled(string nadimciLikova)
        {
            NadimciLikova = nadimciLikova;
        }
    }

    public class PredmetXPPregled : PredmetPregled
    {
        public int BonusUIskustvu { get; set; }
        public string RasePredmet { get; set; }

        public PredmetXPPregled() { }
        public PredmetXPPregled(int bonusUIskustvu, string rasePredmet)
        {
            this.BonusUIskustvu = bonusUIskustvu;
            this.RasePredmet = rasePredmet;
        }
    }

    public class PredmetBasic
    {
        public string Naziv {  get; set; }
        public string Opis { get; set; }
        public string Tip { get; set; }
        public PredmetBasic() { }
        public PredmetBasic(string naziv, string opis)
        {
            this.Naziv = naziv;
            this.Opis = opis;
        }
    }
    public class KljucniPredmetBasic : PredmetBasic
    {
        public string NadimciLikova { get; set; }
        public KljucniPredmetBasic() { }
        public KljucniPredmetBasic(string nadimciLikova)
        {
            this.NadimciLikova = nadimciLikova;
        }
    }
    public class PredmetXPBasic : PredmetBasic
    {
        public int BonusUIskustvu { get; set; }
        public string RasePredmet { get; set; }
        public PredmetXPBasic() { }
        public PredmetXPBasic(int bonusUIskustvu, string rasePredmet)
        {
            BonusUIskustvu = bonusUIskustvu;
            RasePredmet = rasePredmet;
        }
    }
    #endregion
    #region Pomocnik
    public class PomocnikPregled
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Rasa { get; set; }
        public string Klasa { get; set; }
        public int BonusUZastiti { get; set; }

        public PomocnikPregled()
        { }
        public PomocnikPregled(int id, string ime, string rasa, string klasa, int bonusUZastiti)
        {
            Id = id;
            Ime = ime;
            Rasa = rasa;
            Klasa = klasa;
            BonusUZastiti = bonusUZastiti;
        }
    }

    public class PomocnikBasic
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Rasa { get; set; }
        public string Klasa { get; set; }
        public int BonusUZastiti { get; set; }
        public Igrac Igrac { get; set; }

        public PomocnikBasic()
        {

        }

        public PomocnikBasic(int id, string ime, string rasa, string klasa, int bonus)
        {
            this.Id = id;
            this.Ime = ime;
            this.Rasa = rasa;
            this.Klasa = klasa;
            this.BonusUZastiti = bonus;
        }

    }
    #endregion
    #region Proizvod
    public class ProizvodPregled
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Klase {  get; set; }
        public string Rase { get; set; }

        public ProizvodPregled() { }
        public ProizvodPregled(string naziv, string opis, string klase, string rase)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Klase = klase;
            this.Rase = rase;
        }
    }
    public class OklopPregled : ProizvodPregled
    {
        public int PoeniZaOdbranu { get; set; }
        public OklopPregled() { }
        public OklopPregled(int poeniZaOdbranu)
        {
            this.PoeniZaOdbranu = poeniZaOdbranu;
        }
    }
    public class OruzjePregled : ProizvodPregled
    {
        public int PoeniZaNapad {  get; set; }
        public OruzjePregled() { }
        public OruzjePregled(int poeniZaNapad)
        {
            this.PoeniZaNapad = poeniZaNapad;
        }
    }
    public class ProizvodBasic
    {
        public string Naziv {  get; set; }
        public string Tip {  get; set; }
        public string Opis {  get; set; }
        public string Klase {  get; set; }
        public string Rase { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public ProizvodBasic()
        {
            Igraci = new List<Igrac>();
        }
        public ProizvodBasic(string naziv, string tip, string opis,
            string klase, string rase)
        {
            this.Naziv = naziv;
            this.Tip = tip;
            this.Opis = opis;
            this.Klase = klase;
            this.Rase = rase;
        }
    }
    public class OklopBasic : ProizvodBasic
    {
        public int PoeniZaOdbranu { get; set; }
        public OklopBasic() { }
        public OklopBasic(int poeniZaOdbranu)
        {
            this.PoeniZaOdbranu = poeniZaOdbranu;
        }
    }
    public class OruzjeBasic : ProizvodBasic
    {
        public int PoeniZaNapad {  get; set; }
        public OruzjeBasic() { }
        public OruzjeBasic(int poeniZaNapad)
        {
            this.PoeniZaNapad = poeniZaNapad;
        }
    }
    #endregion
    #region Staza
    public class StazaPregled
    {
        public string Naziv {  get; set; }
        public int BonusPoeni {  get; set; }
        public string Potrebne_Rase { get; set; }   
        public string Potreble_Klase { get; set; }

        public StazaPregled() { }
        public StazaPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase)
        {
            this.Naziv = naziv;
            this.BonusPoeni = bonusPoeni;
            this.Potrebne_Rase = potrebne_Rase;
            this.Potreble_Klase = potreble_Klase;
        }
    }
    public class StazaZaIgracaPregled : StazaPregled
    {
        public int BrIgranjaStaze { get; set; }
        public int BrUbijenihNeprijatelja { get; set; }
        public StazaZaIgracaPregled() { }
        public StazaZaIgracaPregled(int brIgranjaStaze, int brUbijenihNeprijatelja)
        {
            BrIgranjaStaze = brIgranjaStaze;
            BrUbijenihNeprijatelja = brUbijenihNeprijatelja;
        }

        public StazaZaIgracaPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase, int brIgranjaStaze, int brUbijenihNeprijatelja) : base(naziv, bonusPoeni, potrebne_Rase, potreble_Klase)
        {
        }
    }
    public class StazaZaTimPregled : StazaPregled
    {
        public Tim Tim { get; set; }
        public StazaZaTimPregled() { }

        public StazaZaTimPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase) : base(naziv, bonusPoeni, potrebne_Rase, potreble_Klase)
        {
        }
    }
    public class StazaBasic
    {
        public string Naziv { get; set; }
        public int BonusPoeni { get; set; }
        public string Potrebne_Rase { get; set; }
        public string Potrebne_Klase { get; set; }
        public string Tip {  get; set; }
        public virtual IList<Predmet> Predmeti { get; set; }

        public StazaBasic()
        {
            this.Predmeti = new List<Predmet>();
        }
        public StazaBasic(string naziv, int bonusPoeni, string potrebne_Rase, string potrebne_Klase, string tip)
        {
            this.Naziv = naziv;
            this.BonusPoeni = bonusPoeni;
            this.Potrebne_Rase = potrebne_Rase;
            this.Potrebne_Klase = potrebne_Klase;
            this.Tip = tip;
        }
    }
    public class StazaZaIgracaBasic : StazaBasic
    {
        public int BrIgranjaStaze { get; set; }
        public int BrUbijenihNeprijatelja {  get; set; }
        public Igrac Igrac {  get; set; }
        public StazaZaIgracaBasic() { }
        public StazaZaIgracaBasic(int brIgranjaStaze, int brUbijenihNeprijatelja, Igrac igrac)
        {
            this.BrIgranjaStaze = brIgranjaStaze;
            this.BrUbijenihNeprijatelja = brUbijenihNeprijatelja;
            this.Igrac = igrac;
        }
    }
    public class StazaZaTimBasic : StazaBasic
    {
        public Tim Tim { get; set; }
        public StazaZaTimBasic() { }
        public StazaZaTimBasic(Tim tim)
        {
            this.Tim = tim;
        }
    }
    #endregion
    #region Lik
    public class LikPregled
    {
        public int ID { get; set; }
        public int KolicinaZlata { get; set; }
        public int Iskustvo {  get; set; }
        public int StepenZamora { get; set; }
        public int NivoZdravstvenogStanja { get; set; }
        public string Klasa {  get; set; }
        public char FCovek {  get; set; }
        public char FPatuljak { get; set; }
        public char FOrk { get; set; }
        public char FDemon { get; set; }
        public char FVilenjak { get; set; }
        public string UmesnostSkrivanja { get; set; }
        public string TipOruzja { get; set; }
        public string EnergijaZaMagiju { get; set; }

        public LikPregled() { }
        public LikPregled(int zlato, int xp, int zamor, int hp,
            string klasa, char fcovek, char fpatuljak, char fork, char fdemon,
            char fvilenjak, string umesnostSkrivanja, string tipOruzja,
            string energijaZaMagiju, int iD)
        {
            this.KolicinaZlata = zlato;
            this.Iskustvo = xp;
            this.StepenZamora = zamor;
            this.NivoZdravstvenogStanja = hp;
            this.Klasa = klasa;
            this.FCovek = fcovek;
            this.FPatuljak = fpatuljak;
            this.FOrk = fork;
            this.FDemon = fdemon;
            this.FVilenjak = fvilenjak;
            this.UmesnostSkrivanja = umesnostSkrivanja;
            this.TipOruzja = tipOruzja;
            this.EnergijaZaMagiju = energijaZaMagiju;
            this.ID = iD;
        }
    }
    public class LopovPregled : LikPregled
    {
        public int MaxNivoZamki { get; set; }
        public int NivoBuke { get; set; }
        public LopovPregled() { }
        public LopovPregled(int maxNivoZamki, int nivoBuke)
        {
            this.MaxNivoZamki = maxNivoZamki;
            this.NivoBuke = nivoBuke;
        }
    }
    public class SvestenikPregled : LikPregled
    {
        public string TipBlagoslova { get; set; }
        public string TipReligije { get; set; }
        public char MogucnostLecenja { get; set; }

        public SvestenikPregled() { }
        public SvestenikPregled(string tipBlagoslova, string tipReligije, char mogucnostLecenja)
        {
            this.TipBlagoslova = tipBlagoslova;
            this.TipReligije = tipReligije;
            this.MogucnostLecenja = mogucnostLecenja;
        }
    }
    public class StrelacPregled : LikPregled
    {
        public char LukIliSamostrel {  get; set; }
        public StrelacPregled() { }
        public StrelacPregled(char lukIliSamostrel)
        {
            this.LukIliSamostrel = lukIliSamostrel;
        }
    }
    public class OklopnikPregled : LikPregled
    {
        public int MaxTezinaOklopa {  get; set; }
        public OklopnikPregled() { }
        public OklopnikPregled(int maxTezinaOklopa)
        {
            this.MaxTezinaOklopa = maxTezinaOklopa;
        }
    }
    public class BoracPregled : LikPregled
    {
        public char OruzjeUObeRuke { get; set; }
        public char KoristiStit {  get; set; }
        public BoracPregled() { }
        public BoracPregled(char oruzjeUObeRuke, char koristiStit)
        {
            this.OruzjeUObeRuke = oruzjeUObeRuke;
            this.KoristiStit = koristiStit;
        }
    }
    public class CarobnjakPregled : LikPregled
    {
        public string SpisakMagija { get; set; }
        public CarobnjakPregled() { }
        public CarobnjakPregled(string spisakMagija)
        {
            this.SpisakMagija = spisakMagija;
        }
    }
    public class LikBasic
    {
        public int Id { get; set; }
        public int KolicinaZlata { get; set; }
        public int Iskustvo {  get; set; }
        public int StepenZamora { get; set; }
        public int NivoZdravstvenogStanja {  get; set; }
        public IgracBasic Igrac {  get; set; }
        public string Klasa {  get; set; }

        public char FCovek {  get; set; }
        public char FPatuljak { get; set; }
        public char FOrk { get; set; }
        public char FDemon { get; set; }
        public char FVilenjak { get; set; }
        public string UmesnostSkrivanja { get; set; }
        public string TipOruzja { get; set; }
        public int EnergijaZaMagiju { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public LikBasic()
        {
            Igraci = new List<Igrac>();
        }

        public LikBasic(int id, string ime, int kolicinaZlata, int iskustvo, int stepenZamora, int nivoZdravstvenogStanja, IgracBasic igrac, string klasa, char fCovek, char fPatuljak, char fOrk, char fDemon, char fVilenjak, string umesnostSkrivanja, string tipOruzja, int energijaZaMagiju)
        {
            this.Id = id;
            this.KolicinaZlata = kolicinaZlata;
            this.Iskustvo = iskustvo;
            this.StepenZamora = stepenZamora;
            this.NivoZdravstvenogStanja = nivoZdravstvenogStanja;
            this.Igrac = igrac;
            this.Klasa = klasa;
            this.FCovek = fCovek;
            this.FPatuljak = fPatuljak;
            this.FOrk = fOrk;
            this.FDemon = fDemon;
            this.FVilenjak = fVilenjak;
            this.UmesnostSkrivanja = umesnostSkrivanja;
            this.TipOruzja = tipOruzja;
            this.EnergijaZaMagiju = energijaZaMagiju;
        }
    }
    public class LopovBasic : LikBasic
    {
        public int MaxNivoZamki {  get; set; }
        public int NivoBuke { get; set; }
        public LopovBasic() { }
        public LopovBasic(int maxNivoZamki, int nivoBuke)
        {
            this.MaxNivoZamki = maxNivoZamki;
            this.NivoBuke = nivoBuke;
        }
    }
    public class SvestenikBasic : LikBasic
    {
        public string TipBlagoslova { get; set; }
        public string TipReligije { get; set; }
        public char MogucnostLecenja { get; set; }

        public SvestenikBasic() { }
        public SvestenikBasic(string tipBlagoslova, string tipReligije, char mogucnostLecenja)
        {
            this.TipBlagoslova = tipBlagoslova;
            this.TipReligije = tipReligije;
            this.MogucnostLecenja = mogucnostLecenja;
        }
    }
    public class StrelacBasic : LikBasic
    {
        public char LukIliSamostrel {  get; set; }
        public StrelacBasic() { }
        public StrelacBasic(char lukIliSamostrel)
        {
            this.LukIliSamostrel = lukIliSamostrel;
        }
    }
    public class OklopnikBasic : LikBasic
    {
        public int MaxTezinaOklopa {  get; set; }
        public OklopnikBasic() { }
        public OklopnikBasic(int maxTezinaOklopa)
        {
            this.MaxTezinaOklopa = maxTezinaOklopa;
        }
    }
    public class BoracBasic : LikBasic
    {
        public char OruzjeUObeRuke { get; set; }
        public char KoristiStit {  get; set; }
        public BoracBasic() { }
        public BoracBasic(char oruzjeUObeRuke, char koristiStit)
        {
            this.OruzjeUObeRuke = oruzjeUObeRuke;
            this.KoristiStit = koristiStit;
        }
    }
    public class CarobnjakBasic : LikBasic
    {
        public string SpisakMagija { get; set; }
        public CarobnjakBasic() { }
        public CarobnjakBasic(string spisakMagija)
        {
            this.SpisakMagija = spisakMagija;
        }
    }
    #endregion
    #region TimVsTim
    public class TimVsTimPregled
    {
        public string Pobednik {  get; set; }
        public string Bonus {  get; set; }
        public string Tim1 {  get; set; }
        public string Tim2 {  get; set; }
        public DateTime Vreme {  get; set; }
        public TimVsTimPregled() { }
        public TimVsTimPregled(string pobednik, string bonus,
            string tim1, string tim2, DateTime vreme)
        {
            this.Tim1 = tim1;
            this.Tim2 = tim2;
            this.Pobednik = pobednik;
            this.Bonus = bonus;
            this.Vreme = vreme;
        }
    }
    #endregion
    #region Kupovina
    public class KupovinaPregled
    {
        public int Id {  get; set; }
        public string Naziv {  get; set; }
        public int Igrac {  get; set; }
        public KupovinaPregled() { }
        public KupovinaPregled(int id, string naziv, int igrac)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Igrac = igrac;
        }
    }
    #endregion
    #region StazaSadrzPredmetPregled
    public class StazaSadrzPredmetPregled
    {
        public int Id { get; set; }
        public string NazivPredmeta { get; set; }
        public string NazivStaze {  get; set; }
        public StazaSadrzPredmetPregled() { }
        public StazaSadrzPredmetPregled(int id, string nazivpredmet, string nazivstaze)
        {
            this.Id = id;
            this.NazivPredmeta = nazivpredmet;
            this.NazivStaze = nazivstaze;
        }
    }
    #endregion
    #region Sesija
    public class SesijaPregled
    {
        public int Id {  get; set; }
        public DateTime VremePovezivanja { get; set; }
        public float VremeUcestvovanja { get; set; }
        public int Gold {  get; set; }
        public int XP { get; set; }

        public SesijaPregled() { }
        public SesijaPregled(int id, DateTime povezivanje, float ucestvovanje, int gold, int xP)
        {
            this.Id = id;
            this.VremePovezivanja = povezivanje;
            this.VremeUcestvovanja = ucestvovanje;
            this.Gold = gold;
            this.XP = xP;
        }
    }
    public class SesijaBasic
    {
        public int Id { get; set; }
        public DateTime VremePovezivanja { get; set; }
        public float VremeUcestvovanja { get; set; }
        public int Gold { get; set; }
        public int XP { get; set; }

        public SesijaBasic()
        {

        }

        public SesijaBasic(int id, DateTime povezivanje, float ucestvovanje, int gold, int xP)
        {
            this.Id = id;
            this.VremePovezivanja = povezivanje;
            this.VremeUcestvovanja = ucestvovanje;
            this.Gold = gold;
            this.XP = xP;
        }

    }
    #endregion Sesija
}