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
    public partial class DodajKreatoraRevijiForm : Form
    {
        public ModnaRevijaBasic revija;
        public DodajKreatoraRevijiForm()
        {
            InitializeComponent();
        }
        public DodajKreatoraRevijiForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KreatorBasic k = new KreatorBasic();
            k.mbr = txtMbr.Text;
            k.ime = txtIme.Text;
            k.prezime = txtPrezime.Text;
            k.datumRodj = dateTimePicker1.Value;
            k.Pol = Char.Parse(txtPol.Text);
            k.zemljaPorekla = txtZemlja.Text;
            k.nazivKuce = txtNaziv.Text;

            DTOManager.dodajKreatoraReviji(k,revija.RbrRevije);
            MessageBox.Show("Uspesno ste dodali kreatora!");
            this.Close();

        }
    }
}
