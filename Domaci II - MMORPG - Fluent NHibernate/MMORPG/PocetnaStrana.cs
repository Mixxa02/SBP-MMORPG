using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMORPG.Forme;

namespace MMORPG
{
    public partial class PocetnaStrana : Form
    {
        public PocetnaStrana()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrikaziIgraca forma= new PrikaziIgraca();
            forma.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KreirajProizvod forma= new KreirajProizvod();
            forma.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajStazu forma= new DodajStazu();
            forma.ShowDialog();
        }
    }
}