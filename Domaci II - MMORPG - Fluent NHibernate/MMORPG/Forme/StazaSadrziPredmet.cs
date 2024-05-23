using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMORPG.Forme
{
    public partial class StazaSadrziPredmet : Form
    {
        public StazaSadrziPredmet()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<StazaSadrzPredmetPregled> lista = DTOManager.vratiSadrzaje();
            foreach (StazaSadrzPredmetPregled i in lista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Id.ToString(), i.NazivPredmeta, i.NazivStaze});
                listView1.Items.Add(item);
            }

            listView1.Refresh();
        }
        private void StazaSadrziPredmet_Load(object sender, EventArgs e)
        {
            this.Text = "StazaSadrziPredmet";
            popuniPodacima();
            List<PredmetPregled> t = DTOManager.vratiPredmete();
            List<StazaPregled> t2 = DTOManager.vratiStaze();
            foreach (PredmetPregled t1 in t)
            {
                comboBox1.Items.Add(t1.Naziv);
            }
            foreach (StazaPregled t1 in t2)
            {
                comboBox2.Items.Add(t1.Naziv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StazaSadrzPredmetPregled o = new StazaSadrzPredmetPregled();
            o.NazivPredmeta = comboBox1.Text;
            o.NazivStaze = comboBox2.Text;
            DTOManager.sacuvajSadrzaj(o);
            MessageBox.Show("Uspesno ste dodali novi predmet na stazi");
            this.Close();
        }
    }
}
