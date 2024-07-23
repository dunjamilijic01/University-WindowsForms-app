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
    public partial class DodajKreatoraForm : Form
    {
        KreatorBasic Kreator;
        public DodajKreatoraForm()
        {
            InitializeComponent();
            Kreator = new KreatorBasic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            this.Kreator.mbr = txtMbr.Text;
            this.Kreator.ime = txtIme.Text;
            this.Kreator.prezime = txtPrezime.Text;
            this.Kreator.datumRodj = dateTimePicker1.Value;
            this.Kreator.Pol = Char.Parse(txtPol.Text);
            this.Kreator.zemljaPorekla = txtZemlja.Text;
            this.Kreator.nazivKuce = txtNaziv.Text;

            DTOManager.dodajKreatora(Kreator);
            MessageBox.Show("Uspesno ste dodali kreatora!");
            this.Close();
        }
    }
}
