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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MMORPG.Forme
{
    public partial class TimVsTim : Form
    {
        public TimVsTim()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<TimVsTimPregled> lista = DTOManager.vratiBorbe();
            foreach (TimVsTimPregled i in lista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Tim1, i.Tim2, i.Pobednik, i.Vreme.ToString(), i.Bonus});
                listView1.Items.Add(item);
            }

            listView1.Refresh();
        }
        private void TimVsTim_Load(object sender, EventArgs e)
        {
            this.Text = "TimVsTim";
            popuniPodacima();
            List<TimPregled> t = DTOManager.vratiTimove();
            foreach (TimPregled t1 in t)
            {
                comboBox1.Items.Add(t1.Naziv);
            }
            foreach (TimPregled t1 in t)
            {
                comboBox2.Items.Add(t1.Naziv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimVsTimPregled o = new TimVsTimPregled();
            o.Tim1 = comboBox1.Text;
            o.Tim2 = comboBox2.Text;
            o.Pobednik = comboBox3.Text;
            o.Vreme = DateTime.Now;
            o.Bonus = textBox1.Text;
            DTOManager.sacuvajBorbu(o);
            MessageBox.Show("Uspesno ste dodali novi mec");
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Add(comboBox1.Text);
            comboBox3.Items.Add(comboBox2.Text);
        }
    }
}
