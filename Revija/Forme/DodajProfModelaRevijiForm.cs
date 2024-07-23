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
    public partial class DodajProfModelaRevijiForm : Form
    {
        ModnaRevijaBasic revija;

        public DodajProfModelaRevijiForm()
        {
            InitializeComponent();
        }
        public DodajProfModelaRevijiForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfesionalniModelBasic model = new ProfesionalniModelBasic();
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

            DTOManager.dodajProfModela(model,revija);

            MessageBox.Show("Uspesno ste dodali novog modela!");

        }
    }
}
