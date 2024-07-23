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
    public partial class IzmeniKreatoraForm : Form
    {
        KreatorBasic kreator;
        public IzmeniKreatoraForm()
        {
            InitializeComponent();
        }
        public IzmeniKreatoraForm(KreatorBasic k)
        {
            InitializeComponent();
            kreator = k;
        }

        private void IzmeniKreatoraForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            txtMbr.Text = kreator.mbr;
            txtIme.Text = kreator.ime;
            txtPrezime.Text = kreator.prezime;
            txtPol.Text = kreator.Pol.ToString();
            if (kreator.datumRodj != null)
            {
                dateTimePicker1.Value = (DateTime)kreator.datumRodj;
            }
            txtZemlja.Text = kreator.zemljaPorekla;
            txtNaziv.Text = kreator.nazivKuce;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmene kreatora?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.kreator.mbr = txtMbr.Text;
                this.kreator.ime = txtIme.Text;
                this.kreator.prezime = txtPrezime.Text;
                this.kreator.datumRodj = dateTimePicker1.Value;
                this.kreator.Pol = Char.Parse(txtPol.Text);
                this.kreator.zemljaPorekla = txtZemlja.Text;
                this.kreator.nazivKuce = txtNaziv.Text;

                DTOManager.izmeniKreatora(this.kreator);
                MessageBox.Show("Azuriranje kreatora je uspesno izvrseno!");
                this.Close();
            }
        }
    }
}
