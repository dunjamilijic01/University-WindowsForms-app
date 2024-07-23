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
    public partial class DodajManekenaForm : Form
    {
        ProfesionalniModelBasic model;
        public DodajManekenaForm()
        {
            InitializeComponent();
            model = new ProfesionalniModelBasic();
        }

        private void button1_Click(object sender, EventArgs e)
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

            DTOManager.dodajProfModela(this.model);

            MessageBox.Show("Uspesno ste dodali novog modela!");
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
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

            DTOManager.dodajProfModela(model);

            MessageBox.Show("Uspesno ste dodali novog modela!");
            Close();
        }
    }
}
