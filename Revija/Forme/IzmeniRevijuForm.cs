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
    public partial class IzmeniRevijuForm : Form
    {
        ModnaRevijaBasic revija;
        public IzmeniRevijuForm()
        {
            InitializeComponent();
        }
        public IzmeniRevijuForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            this.revija = r;
        }

        private void IzmeniRevijuForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"IZMENA MODNE REVIJE {revija.Naziv.ToUpper()}";
        }

        public void popuniPodacima()
        {
            txtRbr.Text = this.revija.RbrRevije.ToString();
            txtNaziv.Text = this.revija.Naziv;
            txtMesto.Text = this.revija.MestoOdrzavanja;
            dateTimePicker1.Value = (DateTime)this.revija.DatumVremeOdrzavanja;
            if (this.revija.PrvaZajednickaRevija == 'Y')
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene revije?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.revija.RbrRevije = Int32.Parse(txtRbr.Text);
                this.revija.Naziv = txtNaziv.Text;
                this.revija.MestoOdrzavanja = txtMesto.Text;
                this.revija.DatumVremeOdrzavanja = dateTimePicker1.Value;
                if (checkBox1.Checked)
                    this.revija.PrvaZajednickaRevija = 'Y';
                else
                    this.revija.PrvaZajednickaRevija = 'N';

                DTOManager.izmeniReviju(this.revija);
                MessageBox.Show("Uspesno ste izmenili reviju!");
                this.Close();
            }
        }
    }
}
