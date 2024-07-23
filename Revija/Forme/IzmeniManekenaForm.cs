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
    public partial class IzmeniManekenaForm : Form
    {
        ProfesionalniModelBasic model;
        public IzmeniManekenaForm()
        {
            InitializeComponent();
        }
        public IzmeniManekenaForm(ProfesionalniModelBasic m)
        {
            InitializeComponent();
            model = m;
        }

        private void IzmeniManekenaForm_Load(object sender, EventArgs e)
        {
            popuniPodatke();
        }
        public void popuniPodatke()
        {
            txtMbr.Text = model.Mbr;
            txtIme.Text = model.Ime;
            txtPol.Text = model.Pol.ToString();
            txtPrezime.Text = model.Prezime;
            if (model.DatRodj != null)
                dateTimePicker1.Value = (DateTime)model.DatRodj;
            txtVisina.Text = model.Visina.ToString();
            txtTezina.Text = model.Tezine.ToString();
            txtOci.Text = model.BojaOciju;
            txtKosa.Text = model.BojaKose;
            txtKonfBr.Text = model.KonfBroj;
            numericUpDown1.Value = model.AgencijaPIB;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            {
                model.Mbr = txtMbr.Text;
                model.Ime = txtIme.Text;
                model.Prezime = txtPrezime.Text;
                model.DatRodj = dateTimePicker1.Value;
                model.Pol = Char.Parse(txtPol.Text);
                model.Visina = Double.Parse(txtVisina.Text);
                model.Tezine = Double.Parse(txtTezina.Text);
                model.BojaOciju = txtOci.Text;
                model.BojaKose = txtKosa.Text;
                model.KonfBroj = txtKonfBr.Text;
                model.AgencijaPIB = Convert.ToInt32(numericUpDown1.Value);

                DTOManager.azurirajProfesionalnogModela(this.model);
                MessageBox.Show("Azuriranje modela je uspesno izvrseno!");
                this.Close();
            }
        }
    }
}
