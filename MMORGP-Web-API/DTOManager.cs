using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate;
using NHibernate.Util;
using MMORGP_Web_API;
using System.Collections;
using MMORGP_Web_API.Entiteti;
using FluentNHibernate.Utils;

namespace MMORGP_Web_API
{
    public class DTOManager
    {
        #region Igrac
        public static List<IgracPregled> vratiIgrace()
        {
            List<IgracPregled> odInfos = new List<IgracPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                //IQuery q = s.CreateQuery("select * from IGRAC");
                //IList<Igrac> igraci = q.List<Igrac>();

                IEnumerable<Igrac> igraci = from o in s.Query<Igrac>()
                                            select o;

                foreach (Igrac i in igraci)
                {
                    odInfos.Add(new IgracPregled(i.Id.ToString(), i.Ime, i.Prezime, i.Nadimak, i.Uzrast));
                }

                s.Close();

            }
            catch (Exception ec)
            {

            }

            return odInfos;
        }
        public static IgracBasic vratiIgraca(int id)
        {
            IgracBasic pb = new IgracBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Igrac o = s.Load<MMORGP_Web_API.Entiteti.Igrac>(id);
                pb = new IgracBasic(o.Id, o.Ime, o.Prezime, o.Nadimak, o.Lozinka, o.Pol, o.Uzrast);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
        }
        public static IgracBasic azurirajIgraca(IgracBasic p, string naziv, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Igrac o = s.Load<MMORGP_Web_API.Entiteti.Igrac>(p.Id);

                Tim t1 = s.Load<MMORGP_Web_API.Entiteti.Tim>(naziv);
                Lik l1 = s.Load<MMORGP_Web_API.Entiteti.Lik>(id);

                o.Ime = p.Ime;
                o.Prezime = p.Prezime;
                o.Lozinka = p.Lozinka;
                o.Nadimak = p.Nadimak;
                o.Pol = p.Pol;
                o.Uzrast = p.Uzrast;
                o.Tim = t1;
                o.Lik = l1;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return p;
        }

        public static void sacuvajIgraca(IgracBasic igrac, string naziv, int id)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Igrac i = new MMORGP_Web_API.Entiteti.Igrac();

                Tim t1 = s.Load<MMORGP_Web_API.Entiteti.Tim>(naziv);
                Lik l1 = s.Load<MMORGP_Web_API.Entiteti.Lik>(id);

                i.Ime = igrac.Ime;
                i.Prezime = igrac.Prezime;
                i.Nadimak = igrac.Nadimak;
                i.Pol = igrac.Pol;
                i.Uzrast = igrac.Uzrast;
                i.Lozinka = igrac.Lozinka;
                i.Tim = t1;
                i.Lik = l1;


                s.Save(i);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiIgraca(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac igrac = s.Load<Igrac>(id);

                s.Delete(igrac);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                
            }


        }
        #endregion
        #region Tim
        public static List<TimPregled> vratiTimove()
        {
            List<TimPregled> Infos = new List<TimPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                //IQuery q = s.CreateQuery("select * from TIM");
                //IList<Tim> timovi = q.List<Tim>();


                IEnumerable<Tim> timovi = from o in s.Query<Tim>()
                                          select o;

                foreach (Tim t in timovi)
                {
                    Infos.Add(new TimPregled(t.Naziv, t.Plasman, t.BonusPoeni, t.Max, t.Min));
                }

                s.Close();
            }
            catch (Exception ec)
            {

            }

            return Infos;
        }
        public static void sacuvajTim(TimBasic tim)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Tim t = new MMORGP_Web_API.Entiteti.Tim();
                /*t.Naziv = t1.Naziv;
                t.Plasman = t1.Plasman;
                t.Min = t1.Min;
                t.Max = t1.Max;
                t.BonusPoeni = t1.BonusPoeni;*/

                t.Naziv = tim.Naziv;
                t.Plasman = tim.Plasman;
                t.Min = tim.Min;
                t.Max = tim.Max;
                t.BonusPoeni = tim.BonusPoeni;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiTim(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Tim tim = s.Load<Tim>(naziv);
                s.Delete(tim);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }
        public static TimBasic izmeniTim(TimBasic tim)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Tim i = s.Load<Tim>(tim.Naziv);
                i.Naziv= tim.Naziv;
                i.Plasman = tim.Plasman;
                i.BonusPoeni = tim.BonusPoeni;
                i.Max = tim.Max;
                i.Min = tim.Min;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return tim;
        }
        #endregion
        #region Pomocnik
        public static List<PomocnikPregled> vratiPomocnike()
        {
            List<PomocnikPregled> odInfos = new List<PomocnikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                //IQuery q = s.CreateQuery("select * from POMOCNIK");
                //IList<Pomocnik> pomocnici = q.List<Pomocnik>();


                IEnumerable<Pomocnik> pomocnici = from o in s.Query<Pomocnik>()
                                                  select o;

                foreach (Pomocnik i in pomocnici)
                {
                    odInfos.Add(new PomocnikPregled(i.Id, i.Ime, i.Rasa, i.Klasa, i.BonusUZastiti));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                
            }

            return odInfos;
        }
        public static void sacuvajPomocnika(PomocnikBasic pom, string idigraca)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Pomocnik p = new MMORGP_Web_API.Entiteti.Pomocnik();
                int ajdi = Convert.ToInt32(idigraca);
                Igrac igrac = s.Load<MMORGP_Web_API.Entiteti.Igrac>(ajdi);

                p.Ime = pom.Ime;
                p.Rasa = pom.Rasa;
                p.Klasa = pom.Klasa;
                p.BonusUZastiti = pom.BonusUZastiti;
                p.Igrac = igrac;


                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiPomocnika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Pomocnik p = s.Load<Pomocnik>(id);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }
        }

        public static PomocnikBasic izmeniPomocnika(PomocnikBasic pomocnik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                MMORGP_Web_API.Entiteti.Pomocnik i = s.Load<MMORGP_Web_API.Entiteti.Pomocnik>(pomocnik.Id);
                int ajdi = Convert.ToInt32(id);
                Igrac igrac = s.Load<MMORGP_Web_API.Entiteti.Igrac>(ajdi);
                i.Ime = pomocnik.Ime;
                i.Rasa = pomocnik.Rasa;
                i.Klasa = pomocnik.Klasa;
                i.BonusUZastiti = pomocnik.BonusUZastiti;
                i.Igrac = igrac;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return pomocnik;
        }
        #endregion
        #region Proizvod
        public static List<ProizvodPregled> vratiProizvode()
        {
            List<ProizvodPregled> odInfos = new List<ProizvodPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                //IQuery q = s.CreateQuery("select * from PROIZVOD");
                //IList<Proizvod> proizvodi = q.List<Proizvod>();


                IEnumerable<Proizvod> proizvodi = from o in s.Query<Proizvod>()
                                                  select o;

                foreach (Proizvod i in proizvodi)
                {
                    odInfos.Add(new ProizvodPregled(i.Naziv, i.Opis, i.Klase, i.Rase));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                
            }

            return odInfos;
        }
        public static void sacuvajProizvod(ProizvodBasic pro, string tipProizvoda, int poeni)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipProizvoda == "Oklop")
                {
                    Entiteti.Oklop ok = new Entiteti.Oklop();
                    ok.Naziv = pro.Naziv;
                    ok.Opis = pro.Opis;
                    ok.Tip = "Oklop";
                    ok.Rase = pro.Rase;
                    ok.Klase = pro.Klase;
                    ok.PoeniZaOdbranu = poeni;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipProizvoda == "Oruzje")
                {
                    Entiteti.Oruzje or = new Entiteti.Oruzje();
                    or.Naziv = pro.Naziv;
                    or.Opis = pro.Opis;
                    or.Tip = "Oruzje";
                    or.Rase = pro.Rase;
                    or.Klase = pro.Klase;
                    or.PoeniZaNapad = poeni;
                    s.Save(or);

                    s.Flush();

                    s.Close();
                }




            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiProizvod(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Proizvod p = s.Load<Proizvod>(naziv);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static OklopBasic izmeniOklop(OklopBasic oklop)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Oklop i = s.Load<Oklop>(oklop.Naziv);
                i.Opis = oklop.Opis;
                i.Rase = oklop.Rase;
                i.Klase = oklop.Klase;
                i.PoeniZaOdbranu = oklop.PoeniZaOdbranu;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec) { }
            return oklop;
        }
        public static OruzjeBasic izmeniOruzje(OruzjeBasic oruzje)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Oruzje i = s.Load<Oruzje>(oruzje.Naziv);
                i.Opis = oruzje.Opis;
                i.Rase = oruzje.Rase;
                i.Klase = oruzje.Klase;
                i.PoeniZaNapad = oruzje.PoeniZaNapad;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec) { }
            return oruzje;
        }
        #endregion
        #region Staza
        public static List<StazaPregled> vratiStaze()
        {
            List<StazaPregled> odInfos = new List<StazaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                //IQuery q = s.CreateQuery("from STAZA");
                //IList<Staza> staze = q.List<Staza>();


                IEnumerable<Staza> staze = from o in s.Query<Staza>()
                                           select o;

                foreach (Staza i in staze)
                {
                    odInfos.Add(new StazaPregled(i.Naziv, i.BonusPoeni, i.Potrebne_Klase, i.Potrebne_Rase));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                
            }

            return odInfos;
        }
        public static void sacuvajStazu(StazaBasic staza, string tipStaze, int brigr, int brUb, int igrId, string tim)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipStaze == "Igrac")
                {
                    Entiteti.StazaZaIgraca ok = new Entiteti.StazaZaIgraca();
                    ok.Naziv = staza.Naziv;
                    ok.BonusPoeni = staza.BonusPoeni;
                    ok.Tip = "Igrac";
                    ok.Potrebne_Rase = staza.Potrebne_Rase;
                    ok.Potrebne_Klase = staza.Potrebne_Klase;
                    ok.BrIgranjaStaze = brigr;
                    ok.BrUbijenihNeprijatelja = brUb;
                    Entiteti.Igrac igrac = s.Load<Entiteti.Igrac>(igrId);
                    ok.Igrac = igrac;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipStaze == "Tim")
                {
                    Entiteti.StazaZaTim or = new Entiteti.StazaZaTim();
                    or.Naziv = staza.Naziv;
                    or.BonusPoeni = staza.BonusPoeni;
                    or.Tip = "Tim";
                    or.Potrebne_Rase = staza.Potrebne_Rase;
                    or.Potrebne_Klase = staza.Potrebne_Klase;
                    Entiteti.Tim tims = s.Load<Entiteti.Tim>(tim);
                    or.Tim = tims;
                    s.Save(or);

                    s.Flush();

                    s.Close();
                }




            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiStazu(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Staza staza = s.Load<Staza>(naziv);
                s.Delete(staza);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static StazaZaIgracaBasic izmeniStazuZaIgraca(StazaZaIgracaBasic staza)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                StazaZaIgraca i = s.Load<StazaZaIgraca>(staza.Naziv);
                i.BonusPoeni = staza.BonusPoeni;
                i.Potrebne_Klase = staza.Potrebne_Klase;
                i.Potrebne_Rase = staza.Potrebne_Rase;
                i.BrIgranjaStaze = staza.BrIgranjaStaze;
                i.BrUbijenihNeprijatelja = staza.BrUbijenihNeprijatelja;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return staza;
        }
        public static StazaZaTimBasic izmeniStazuZaTim(StazaZaTimBasic staza)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                StazaZaTim i = s.Load<StazaZaTim>(staza.Naziv);
                i.BonusPoeni = staza.BonusPoeni;
                i.Potrebne_Klase = staza.Potrebne_Klase;
                i.Potrebne_Rase = staza.Potrebne_Rase;
                i.Tim = staza.Tim;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return staza;
        }
        #endregion
        #region Predmet
        public static List<PredmetPregled> vratiPredmete()
        {
            List<PredmetPregled> odInfos = new List<PredmetPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                //IQuery q = s.CreateQuery("select * from PREDMET");
                //IList<Predmet> predmeti = q.List<Predmet>();


                IEnumerable<Predmet> predmeti = from o in s.Query<Predmet>()
                                                select o;

                foreach (Predmet i in predmeti)
                {
                    odInfos.Add(new PredmetPregled(i.Naziv, i.Opis));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                
            }

            return odInfos;
        }
        public static void sacuvajPredmet(PredmetBasic pr, string tipPredmeta, string nadimci, int bonisk, string rase)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipPredmeta == "Kljucni")
                {
                    Entiteti.KljucniPredmet ok = new Entiteti.KljucniPredmet();
                    ok.Naziv = pr.Naziv;
                    ok.Opis = pr.Opis;
                    ok.NadimciLikova = nadimci;
                    //Entiteti.Staza st = s.Load<Entiteti.Staza>(staza);
                    //ok.Staze = st.Naziv;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipPredmeta == "XP")
                {
                    Entiteti.PredmetXP or = new Entiteti.PredmetXP();
                    or.Naziv = pr.Naziv;
                    or.Opis = pr.Opis;
                    or.BonusUIskustvu = bonisk;
                    or.RasePremdet = rase;
                    //Entiteti.Staza st = s.Load<Entiteti.Staza>(staza);
                    //or.Naziv = st.Naziv;
                    s.Save(or);

                    s.Flush();

                    s.Close();
                }




            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiPredmet(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predmet p = s.Load<Predmet>(naziv);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static KljucniPredmetBasic izmeniKljucniPredmet(KljucniPredmetBasic predmet)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                KljucniPredmet i = s.Load<KljucniPredmet>(predmet.Naziv);
                i.Opis = predmet.Opis;
                i.NadimciLikova = predmet.NadimciLikova;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return predmet;
        }

        public static PredmetXPBasic izmeniPredmetXP(PredmetXPBasic predmet)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PredmetXP i = s.Load<PredmetXP>(predmet.Naziv);
                i.Opis = predmet.Opis;
                i.BonusUIskustvu = predmet.BonusUIskustvu;
                i.RasePremdet = predmet.RasePredmet;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return predmet;
        }
        #endregion
        #region Lik
        public static List<LikPregled> vratiLikove()
        {
            List<LikPregled> odInfos = new List<LikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                //IQuery q = s.CreateQuery("select * from LIK");
                //IList<Lik> likovi = q.List<Lik>();


                IEnumerable<Lik> likovi = from o in s.Query<Lik>()
                                          select o;

                foreach (Lik i in likovi)
                {
                    odInfos.Add(new LikPregled(i.KolicinaZlata, i.Iskustvo, i.StepenZamora, i.NivoZdravstvenogStanja,
                        i.Klasa, i.FCovek, i.FPatuljak, i.FOrk, i.FDemon, i.FVilenjak, i.UmesnostSkrivanja, i.TipOruzja, i.EnergijaZaMagiju.ToString(), i.Id));
                }

                s.Close();

            }
            catch (Exception ec)
            {
               
            }

            return odInfos;
        }
        public static void sacuvajLika(LikBasic lik, string klasaLika, string rasaLika, int zamke, int buka, string religija,
            string blagoslov, char lecenje, char luksamostrel, int oklop, char oberuke, char stit, string magije)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (klasaLika == "LOPOV")
                {
                    Entiteti.Lopov ok = new Entiteti.Lopov();
                    ok.Id = lik.Id;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = lik.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.MaxNivoZamki = zamke;
                    ok.NivoBuke = buka;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    //Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    //ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "SVESTENIK")
                {
                    Entiteti.Svestenik ok = new Entiteti.Svestenik();
                    ok.Id = lik.Id;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = lik.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.TipBlagoslova = blagoslov;
                    ok.TipReligije = religija;
                    ok.MogucnostLecenja = lecenje;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    //Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    //ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                if (klasaLika == "STRELAC")
                {
                    Entiteti.Strelac ok = new Entiteti.Strelac();
                    ok.Id = lik.Id;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = lik.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.LukIliSamostrel = luksamostrel;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    //Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    //ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "OKLOPNIK")
                {
                    Entiteti.Oklopnik ok = new Entiteti.Oklopnik();
                    ok.Id = lik.Id;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = lik.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.MaxTezinaOklopa = oklop;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    //Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    //ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                if (klasaLika == "BORAC")
                {
                    Entiteti.Borac ok = new Entiteti.Borac();
                    ok.Id = lik.Id;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = lik.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.OruzjeUObeRuke = oberuke;
                    ok.KoristiStit = stit;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    //Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    //ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "CAROBNJAK")
                {
                    Entiteti.Carobnjak ok = new Entiteti.Carobnjak();
                    ok.Id = lik.Id;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = lik.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.SpisakMagija = magije;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    //Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    //ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }



            }
            catch (Exception ec)
            {
                
            }
        }
        public static void obrisiLika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lik l = s.Load<Lik>(id);
                s.Delete(l);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static LopovBasic izmeniLopova(LopovBasic lik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lopov i = s.Load<Lopov>(lik.Id);
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.MaxNivoZamki = lik.MaxNivoZamki;
                i.NivoBuke = lik.NivoBuke;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static SvestenikBasic izmeniSvestenika(SvestenikBasic lik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Svestenik i = s.Load<Svestenik>(lik.Id);
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.TipBlagoslova = lik.TipBlagoslova;
                i.TipReligije = lik.TipReligije;
                i.MogucnostLecenja = lik.MogucnostLecenja;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static StrelacBasic izmeniStrelca(StrelacBasic lik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Strelac i = s.Load<Strelac>(lik.Id);
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.LukIliSamostrel = lik.LukIliSamostrel;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static OklopnikBasic izmeniOklopnika(OklopnikBasic lik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Oklopnik i = s.Load<Oklopnik>(lik.Id);
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.MaxTezinaOklopa = lik.MaxTezinaOklopa;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static BoracBasic izmeniBorca(BoracBasic lik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Borac i = s.Load<Borac>(lik.Id);
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.OruzjeUObeRuke = lik.OruzjeUObeRuke;
                i.KoristiStit = lik.KoristiStit;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static CarobnjakBasic izmeniCarobnjaka(CarobnjakBasic lik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Carobnjak i = s.Load<Carobnjak>(lik.Id);
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.SpisakMagija = lik.SpisakMagija;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        #endregion
        #region TimVsTim
        public static List<TimVsTimPregled> vratiBorbe()
        {
            List<TimVsTimPregled> Infos = new List<TimVsTimPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IEnumerable<TimVsTim> timovi = from o in s.Query<TimVsTim>()
                                               select o;

                foreach (TimVsTim t in timovi)
                {
                    Infos.Add(new TimVsTimPregled(t.Pobednik, t.Bonus, t.Tim1, t.Tim2, t.Vreme));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                
            }

            return Infos;
        }
        public static void sacuvajBorbu(TimVsTimPregled tim)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.TimVsTim t = new MMORGP_Web_API.Entiteti.TimVsTim();

                t.Tim1 = tim.Tim1;
                t.Tim2 = tim.Tim2;
                t.Pobednik = tim.Pobednik;
                t.Vreme = tim.Vreme;
                t.Bonus = tim.Bonus;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        #endregion
        #region Kupovina
        public static List<KupovinaPregled> vratiKupovine()
        {
            List<KupovinaPregled> Infos = new List<KupovinaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IEnumerable<Kupovina> k = from o in s.Query<Kupovina>()
                                          select o;

                foreach (Kupovina t in k)
                {
                    Infos.Add(new KupovinaPregled(t.Id, t.Naziv, t.Igrac));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                
            }

            return Infos;
        }
        public static void sacuvajKupovinu(KupovinaPregled k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Kupovina t = new MMORGP_Web_API.Entiteti.Kupovina();

                t.Naziv = k.Naziv;
                t.Igrac = k.Igrac;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        #endregion
        #region StazaSadrziPredmet
        public static List<StazaSadrzPredmetPregled> vratiSadrzaje()
        {
            List<StazaSadrzPredmetPregled> Infos = new List<StazaSadrzPredmetPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IEnumerable<StazaSadrziPredmet> k = from o in s.Query<StazaSadrziPredmet>()
                                                    select o;

                foreach (StazaSadrziPredmet t in k)
                {
                    Infos.Add(new StazaSadrzPredmetPregled(t.Id, t.NazivPredmeta, t.NazivStaze));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                
            }

            return Infos;
        }
        public static void sacuvajSadrzaj(StazaSadrzPredmetPregled k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.StazaSadrziPredmet t = new MMORGP_Web_API.Entiteti.StazaSadrziPredmet();

                t.NazivPredmeta = k.NazivPredmeta;
                t.NazivStaze = k.NazivStaze;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        #endregion
        #region Sesija
        public static List<SesijaPregled> vratiSesije()
        {
            List<SesijaPregled> odInfos = new List<SesijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sesija> sesije = from o in s.Query<Sesija>()
                                             select o;

                foreach (Sesija i in sesije)
                {
                    odInfos.Add(new SesijaPregled(i.Id, i.VremePovezivanjaNaServer, i.VremeUcestvovanja, i.ZaradjeniGold, i.ZaradjeniXPpoeni));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                
            }

            return odInfos;
        }
        public static void sacuvajSesiju(SesijaBasic pom, string idigraca)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORGP_Web_API.Entiteti.Sesija p = new MMORGP_Web_API.Entiteti.Sesija();
                int ajdi = Convert.ToInt32(idigraca);
                Igrac igrac = s.Load<MMORGP_Web_API.Entiteti.Igrac>(ajdi);

                p.VremeUcestvovanja = pom.VremeUcestvovanja;
                p.VremePovezivanjaNaServer = pom.VremePovezivanja;
                p.ZaradjeniGold = pom.Gold;
                p.ZaradjeniXPpoeni = pom.XP;
                p.Igrac = igrac;

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                
            }
        }
        #endregion
    }
}
