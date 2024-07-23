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
    public partial class CasopisDodajForm : Form
    {
        ProfesionalniModelBasic model;
        public CasopisDodajForm()
        {
            InitializeComponent();
        }
        public CasopisDodajForm(ProfesionalniModelBasic m)
        {
            InitializeComponent();
            model = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTOManager.dodajNaslovnuStranu(model, textBox1.Text);
            MessageBox.Show("Uspesno ste dodali naslovnu stranu!");
            Close();
        }

        private void CasopisDodajForm_Load(object sender, EventArgs e)
        {
        }

    }
}
