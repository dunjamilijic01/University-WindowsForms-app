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
    public partial class IzmeniNaslovnuStranuForm : Form
    {
        NaslovnaStranaBasic str;
        public IzmeniNaslovnuStranuForm()
        {
            InitializeComponent();
        }
        public IzmeniNaslovnuStranuForm(NaslovnaStranaBasic n)
        {
            InitializeComponent();
            str = n;
        }

        private void IzmeniNaslovnuStranuForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            textBox1.Text = str.NazivCasopisa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.str.NazivCasopisa = textBox1.Text;
            DTOManager.IzmeniNaslovnuStranu(this.str);
            MessageBox.Show("Uspesno izmenjena naslovna strana");
            Close();
        }
    }
}
