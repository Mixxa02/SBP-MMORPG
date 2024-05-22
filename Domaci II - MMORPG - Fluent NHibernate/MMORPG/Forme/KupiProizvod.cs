using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MMORPG.Forme
{
    public partial class KupiProizvod : Form
    {
        public KupiProizvod()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KupovinaPregled> lista = DTOManager.vratiKupovine();
            foreach (KupovinaPregled i in lista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Id.ToString(), i.Naziv, i.Igrac.ToString()});
                listView1.Items.Add(item);
            }

            listView1.Refresh();
        }
        private void KupiProizvod_Load(object sender, EventArgs e)
        {
            this.Text = "KupiProizvod";
            popuniPodacima();
            List<ProizvodPregled> t = DTOManager.vratiProizvode();
            List<IgracPregled> t2 = DTOManager.vratiIgrace();
            foreach (ProizvodPregled t1 in t)
            {
                comboBox1.Items.Add(t1.Naziv);
            }
            foreach (IgracPregled t1 in t2)
            {
                comboBox2.Items.Add(t1.ID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KupovinaPregled o = new KupovinaPregled();
            o.Naziv = comboBox1.Text;
            o.Igrac = Convert.ToInt32(comboBox2.Text);
            DTOManager.sacuvajKupovinu(o);
            MessageBox.Show("Uspesno ste dodali novu kupovinu");
            this.Close();
        }
    }
}
