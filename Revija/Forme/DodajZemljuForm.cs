using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revija.Forme
{
    public partial class DodajZemljuForm : Form
    {
        int pib;
        public DodajZemljuForm()
        {
            InitializeComponent();
        }
        public DodajZemljuForm(int id)
        {
            InitializeComponent();
            pib = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naziv = textBox1.Text;
            DTOManager.dodajZemlju(naziv,pib);
            MessageBox.Show("Uspesno ste dodali zemlju");
            Close();
        }
    }
}
