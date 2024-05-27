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
    public partial class IzmenaIgraca : Form
    {
        public IgracBasic i;
        public IzmenaIgraca()
        {
            InitializeComponent();
        }
        public IzmenaIgraca(IgracBasic p)
        {
            InitializeComponent();
            this.i=p;
        }

        private void IzmenaIgraca_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            List<TimPregled> t = DTOManager.vratiTimove();
            List<LikPregled> l = DTOManager.vratiLikove();
            foreach (TimPregled t1 in t)
            {
                comboBox1.Items.Add(t1.Naziv);
            }
            foreach (LikPregled l1 in l)
            {
                comboBox2.Items.Add(l1.ID);
            }
        }
        public void popuniPodacima()
        {
            textBox1.Text = this.i.Ime;
            textBox2.Text = this.i.Prezime;
            textBox3.Text = this.i.Nadimak;
            textBox4.Text = this.i.Lozinka;
            numericUpDown1.Value = this.i.Uzrast;
            if (this.i.Pol == 'M')
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmenu igraca?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.i.Ime = textBox1.Text;
                this.i.Prezime = textBox2.Text;
                this.i.Nadimak = textBox3.Text;
                this.i.Lozinka = textBox4.Text;
                this.i.Uzrast = (int)numericUpDown1.Value;
                if (radioButton1.Checked == true)
                    this.i.Pol = 'M';
                else
                    this.i.Pol = 'Z';
                DTOManager.azurirajIgraca(this.i, comboBox1.Text, Convert.ToInt32(comboBox2.Text));
                MessageBox.Show("Azuriranje igraca je uspesno izvrseno!");
                this.Close();
            }
        }
    }
}
