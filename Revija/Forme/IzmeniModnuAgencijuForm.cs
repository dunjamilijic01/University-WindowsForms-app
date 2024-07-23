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
    public partial class IzmeniModnuAgencijuForm : Form
    {
        int pib;
        public IzmeniModnuAgencijuForm()
        {
            InitializeComponent();
        }
        public IzmeniModnuAgencijuForm(int pib)
        {
            InitializeComponent();
            this.pib = pib;
            popuniPodatke();
        }
        public void popuniPodatke()
        {
            ModnaAgencijaBasic m = DTOManager.vratiModnuAgenciju(pib);
            numericUpDown1.Value = m.PIB;
            txtNaziv.Text = m.Naziv;
            txtSediste.Text = m.Sediste;
            if (m.DatumOsnivanja != null)
                dateTimePicker1.Value = (DateTime)m.DatumOsnivanja;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModnaAgencijaBasic m = new ModnaAgencijaBasic();
            m.PIB = Convert.ToInt32(numericUpDown1.Value);
            m.Naziv = txtNaziv.Text;
            m.Sediste = txtSediste.Text;
            m.DatumOsnivanja = dateTimePicker1.Value;
           
            DTOManager.izmeniModnuAgenciju(m);
            MessageBox.Show("Agencija uspesno izmenjena");
            Close();
        }
    }
}
