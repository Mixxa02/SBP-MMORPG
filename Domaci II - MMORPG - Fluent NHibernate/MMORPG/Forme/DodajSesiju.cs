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

namespace MMORPG.Forme
{
    public partial class DodajSesiju : Form
    {
        public DodajSesiju()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<SesijaPregled> pomLista = DTOManager.vratiSesije();
            foreach (SesijaPregled i in pomLista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Id.ToString(), i.VremePovezivanja.ToString(), i.VremeUcestvovanja.ToString(), i.Gold.ToString(), i.XP.ToString() });
                listView1.Items.Add(item);
            }

            listView1.Refresh();
        }

        private void DodajSesiju_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            List<IgracPregled> t = DTOManager.vratiIgrace();
            foreach (IgracPregled t1 in t)
            {
                comboBox1.ValueMember = t1.ID;
                comboBox1.Items.Add(t1.Ime + " " + t1.Prezime);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SesijaBasic o = new SesijaBasic();
            o.VremePovezivanja = DateTime.Now;
            o.VremeUcestvovanja = float.Parse(textBox1.Text);
            o.Gold = Convert.ToInt32(textBox2.Text);
            o.XP = Convert.ToInt32(textBox3.Text);

            DTOManager.sacuvajSesiju(o, comboBox1.ValueMember);
            MessageBox.Show("Uspesno ste dodali novu sesiju!");
            this.Close();
        }
    }
}
