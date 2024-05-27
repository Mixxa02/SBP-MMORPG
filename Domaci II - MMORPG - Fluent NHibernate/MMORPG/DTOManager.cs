﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMORPG.Entiteti;
using NHibernate.Linq;
using NHibernate;
using NHibernate.Util;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace MMORPG
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
                MessageBox.Show(ec.Message);
            }

            return odInfos;
        }
        public static IgracBasic vratiIgraca(int id)
        {
            IgracBasic pb = new IgracBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.Igrac o = s.Load<MMORPG.Entiteti.Igrac>(id);
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

                MMORPG.Entiteti.Igrac o = s.Load<MMORPG.Entiteti.Igrac>(p.Id);

                Tim t1 = s.Load<MMORPG.Entiteti.Tim>(naziv);
                Lik l1 = s.Load<MMORPG.Entiteti.Lik>(id);

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

                MMORPG.Entiteti.Igrac i = new MMORPG.Entiteti.Igrac();

                Tim t1 = s.Load<MMORPG.Entiteti.Tim>(naziv);
                Lik l1 = s.Load<MMORPG.Entiteti.Lik>(id);

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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }

            return Infos;
        }
        public static void sacuvajTim(TimBasic tim)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.Tim t = new MMORPG.Entiteti.Tim();
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
                MessageBox.Show(ec.Message);
            }
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
                MessageBox.Show(ec.Message);
            }

            return odInfos;
        }
        public static void sacuvajPomocnika(PomocnikBasic pom, string idigraca)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.Pomocnik p = new MMORPG.Entiteti.Pomocnik();
                int ajdi = Convert.ToInt32(idigraca);
                Igrac igrac = s.Load<MMORPG.Entiteti.Igrac>(ajdi);

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
                MessageBox.Show(ec.Message);
            }
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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }
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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }
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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }
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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }
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
                MessageBox.Show(ec.Message);
            }

            return Infos;
        }
        public static void sacuvajBorbu(TimVsTimPregled tim)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.TimVsTim t = new MMORPG.Entiteti.TimVsTim();

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
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }

            return Infos;
        }
        public static void sacuvajKupovinu(KupovinaPregled k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.Kupovina t = new MMORPG.Entiteti.Kupovina();

                t.Naziv = k.Naziv;
                t.Igrac = k.Igrac;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }

            return Infos;
        }
        public static void sacuvajSadrzaj(StazaSadrzPredmetPregled k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.StazaSadrziPredmet t = new MMORPG.Entiteti.StazaSadrziPredmet();

                t.NazivPredmeta = k.NazivPredmeta;
                t.NazivStaze = k.NazivStaze;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
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
                MessageBox.Show(ec.Message);
            }

            return odInfos;
        }
        public static void sacuvajSesiju(SesijaBasic pom, string idigraca)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                MMORPG.Entiteti.Sesija p = new MMORPG.Entiteti.Sesija();
                int ajdi = Convert.ToInt32(idigraca);
                Igrac igrac = s.Load<MMORPG.Entiteti.Igrac>(ajdi);

                p.VremeUcestvovanja = pom.VremeUcestvovanja;
                p.VremePovezivanjaNaServer = pom.VremePovezivanja;
                p.ZaradjeniGold = pom.Gold;
                p.ZaradjeniXPpoeni = pom.XP;
                p.Igrac= igrac;

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        #endregion
    }
}
