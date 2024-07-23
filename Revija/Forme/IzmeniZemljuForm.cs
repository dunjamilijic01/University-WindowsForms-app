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
   
    public partial class IzmeniZemljuForm : Form
    {
        PoslujeUBasic posluje;
        public IzmeniZemljuForm()
        {
            InitializeComponent();
        }
        public IzmeniZemljuForm(PoslujeUBasic p)
        {
            InitializeComponent();
            posluje = p;
        }

        private void IzmeniZemljuForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = posluje.NazivZemlje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.posluje.NazivZemlje = textBox1.Text;
            DTOManager.izmeniZemlju(this.posluje);
            MessageBox.Show("Uspesno ste izmenili naziv zemlje");
            Close();
        }
    }
}
