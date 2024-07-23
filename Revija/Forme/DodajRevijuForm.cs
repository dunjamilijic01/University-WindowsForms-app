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
    public partial class DodajRevijuForm : Form
    {
        ModnaRevijaBasic revija;
        public DodajRevijuForm()
        {
            InitializeComponent();
            revija = new ModnaRevijaBasic();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novu modnu reviju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if(result==DialogResult.OK)
            {
                this.revija.RbrRevije = Int32.Parse(txtRbr.Text);
                this.revija.Naziv = txtNaziv.Text;
                this.revija.MestoOdrzavanja = txtNaziv.Text;
                this.revija.DatumVremeOdrzavanja = dateTimePicker1.Value;
                if (chbxPrvaZaj.Checked)
                    this.revija.PrvaZajednickaRevija = 'Y';
                else
                    this.revija.PrvaZajednickaRevija = 'N';

                DTOManager.dodajReviju(this.revija);
                MessageBox.Show("Uspesno ste dodali novu reviju!");
                this.Close();
            }
            else
            {

            }
        }
    }
}
