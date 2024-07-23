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
    public partial class DodajVipNaRevijiForm : Form
    {
        ModnaRevijaBasic revija;
        public DodajVipNaRevijiForm()
        {
            InitializeComponent();
        }
        public DodajVipNaRevijiForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VIPBasic vip = new VIPBasic();
            vip.Mbr = txtMbr.Text;
            vip.Ime = txtIme.Text;
            vip.Prezime = txtPrezime.Text;
            vip.Pol = Char.Parse(txtPol.Text);
            vip.DatRodj = dateTimePicker1.Value;
            vip.Zanimanje = txtZanimanje.Text;
            DTOManager.dodajVipModela(vip,revija);

            MessageBox.Show("Uspesno ste dodali novog VIP-a!");
        }
    }
}
