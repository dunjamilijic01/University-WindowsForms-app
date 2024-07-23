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
    public partial class DodajAgencijuForm : Form
    {
        public DodajAgencijuForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModnaAgencijaBasic m = new ModnaAgencijaBasic();
            m.PIB = Convert.ToInt32(numericUpDown1.Value);
            m.Naziv = txtNaziv.Text;
            m.Sediste = txtSediste.Text;
            m.DatumOsnivanja = dateTimePicker1.Value;
            m.Tip = comboBox1.SelectedItem.ToString();

            DTOManager.dodajModnuAgenciju(m);
            MessageBox.Show("Uspesno ste dodali modnu agenciju");
            Close();
        }
    }
}
