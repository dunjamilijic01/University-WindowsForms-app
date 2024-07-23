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
    public partial class IzmeniAgencijuForm : Form
    {
        ModnaAgencijaBasic agencija;
        public IzmeniAgencijuForm()
        {
            InitializeComponent();
        }
        public IzmeniAgencijuForm(ModnaAgencijaBasic a)
        {
            InitializeComponent();
            agencija = a;
        }

        private void IzmeniAgencijuForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            numericUpDown1.Value = agencija.PIB;
            txtNaziv.Text = agencija.Naziv;
            txtSediste.Text = agencija.Sediste;
            if (agencija.DatumOsnivanja != null)
                dateTimePicker1.Value = (DateTime)agencija.DatumOsnivanja;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.agencija.PIB = Convert.ToInt32(numericUpDown1.Value);
            this.agencija.Naziv = txtNaziv.Text;
            this.agencija.Sediste = txtSediste.Text;
            this.agencija.DatumOsnivanja = dateTimePicker1.Value;

            DTOManager.izmeniModnuAgenciju(this.agencija);
            MessageBox.Show("Uspesno ste izmenili modnu agenciju!");
            Close();
        }
    }
}
