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
    public partial class IzmeniManekenaNaRevijiForm : Form
    {
        public ProfesionalniModelBasic model;
        public IzmeniManekenaNaRevijiForm()
        {
            InitializeComponent();
        }

        public IzmeniManekenaNaRevijiForm(ProfesionalniModelBasic m)
        {
            InitializeComponent();
            model = m;
        }

        private void txtVisina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTezina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void IzmeniManekenaNaRevijiForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            txtMbr.Text = model.Mbr;
            txtIme.Text = model.Ime;
            txtPrezime.Text = model.Prezime;
            txtPol.Text = model.Pol.ToString();
            txtVisina.Text =model.Visina.ToString();
            txtTezina.Text = model.Tezine.ToString();
            txtOci.Text = model.BojaOciju;
            txtKosa.Text = model.BojaKose;
            txtKonfBr.Text = model.KonfBroj;
            dateTimePicker1.Value = ((DateTime)model.DatRodj);
            numericUpDown1.Value = model.AgencijaPIB;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene modela?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.model.Mbr = txtMbr.Text;
                this.model.Ime = txtIme.Text;
                this.model.Prezime = txtPrezime.Text;
                this.model.DatRodj = dateTimePicker1.Value;
                this.model.Pol = Char.Parse(txtPol.Text);
                this.model.Visina = Double.Parse(txtVisina.Text);
                this.model.Tezine = Double.Parse(txtTezina.Text);
                this.model.BojaOciju = txtOci.Text;
                this.model.BojaKose = txtKosa.Text;
                this.model.KonfBroj = txtKonfBr.Text;
                this.model.AgencijaPIB = Convert.ToInt32(numericUpDown1.Value);

                DTOManager.azurirajProfesionalnogModela(this.model);
                MessageBox.Show("Azuriranje modela je uspesno izvrseno!");
                this.Close();
            }
        }
    }
}
