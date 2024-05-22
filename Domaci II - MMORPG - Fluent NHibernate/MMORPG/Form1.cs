using MMORPG.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using static MMORPG.Entiteti.Staza;

namespace MMORPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdPodaciOIgracu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Igrac p = s.Load<Igrac>(100001);

                MessageBox.Show(p.Lozinka);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodajTim_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Tim p = new Entiteti.Tim();

                //p = s.Load<Entiteti.Prodavnica>(81);

                p.Naziv = "Tim5";
                p.Plasman = 5;
                p.BonusPoeni = 204;
                p.Max = 5;
                p.Min = 1;


                //s.Save(p);
                s.SaveOrUpdate(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOne_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Igrac o = s.Load<Igrac>(100000);

                MessageBox.Show(o.Lozinka);
                MessageBox.Show(o.Tim.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici sa zadatim brojem
                MMORPG.Entiteti.Tim p = s.Load<MMORPG.Entiteti.Tim>("Zmajevi");

                foreach (Igrac o in p.Igraci)
                {
                    MessageBox.Show(o.Lozinka + " " + o.Uzrast);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajIgraca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tim p = new Entiteti.Tim()
                {
                    Naziv = "TIM",
                    Plasman = 7,
                    BonusPoeni = 100,
                    Max = 23,
                    Min = 11
                };

                Igrac o = new Igrac()
                {
                    Ime = "Stefan",
                    Prezime = "Petrovic",
                    Pol = 'M',
                    Nadimak = "stefi",
                    Lozinka = "stefi123",
                    Uzrast = 20
                };

                o.Tim = p;

                p.Igraci.Add(o);

                s.Save(o);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac i1 = s.Load<Igrac>(100001);

                foreach (Entiteti.Proizvod p1 in i1.Proizvodi)
                {
                    MessageBox.Show(p1.Naziv);
                }


                Entiteti.Proizvod p2 = s.Load<Entiteti.Proizvod>("Mac");

                foreach (Igrac i2 in p2.Igraci)
                {
                    MessageBox.Show(i2.Ime + " " + i2.Prezime);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void svestenikBtn_Click(object sender, EventArgs e)
        {
            /*try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Lik l = s.Load<Lik>(1);

                MessageBox.Show(l.KolicinaZlata.ToString());
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }*/
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Igrac i = s.Load<MMORPG.Entiteti.Igrac>(100001);

                Oruzje o = new Oruzje()
                {
                    Naziv = "Mac",
                    Opis = "Efektan je za borbu izbliza",
                    Klase = "CAROBNJAK, BORAC, OKLOPNIK, SVESTENIK, LOPOV",
                    Rase = "COVEK, PATULJAK, ORK, VILENJAK, DEMON",
                    PoeniZaNapad = 99
                };

                o.Igraci.Add(i);
                i.Proizvodi.Add(o);
                s.Save(o);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tim tim = s.Load<MMORPG.Entiteti.Tim>("Zmajevi");
                //Entiteti.Igrac i = s.Load<MMORPG.Entiteti.Igrac>(1);

                StazaZaTim st = new StazaZaTim();

                st.Naziv = "Mountain";
                st.BonusPoeni = 33;
                st.Potrebne_Klase = "STRELAC, BORAC, CAROBNJAK";
                st.Potrebne_Rase = "COVEK, VILENJAK, PATULJAK";
                //st.BrIgranjaStaze = 3;
                //st.BrUbijenihNeprijatelja = 31;
                st.Tim = tim;
                

                s.Save(st);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void createSesija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Igrac p = s.Load<Entiteti.Igrac>(100001);

                Sesija s1 = new Sesija();
                s1.ZaradjeniGold = 20;
                s1.ZaradjeniXPpoeni = 25;
                s1.VremePovezivanjaNaServer = DateTime.Now;
                s1.VremeUcestvovanja = 5.3f;

                s.Save(s1);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnTimVsTim_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tim t1 = s.Load<Entiteti.Tim>("Real");
                Entiteti.Tim t2 = s.Load<Entiteti.Tim>("Zuti");

                TimVsTim mec = new TimVsTim();

                mec.Tim1 = t1.Naziv;
                mec.Tim2 = t2.Naziv;
                mec.Pobednik = t1.Naziv;
                mec.Vreme = DateTime.Now;

                s.Save(mec);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}