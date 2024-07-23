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
   
    public partial class IzmeniVipNaRevijiForm : Form
    {
        public VIPBasic vip;
        public IzmeniVipNaRevijiForm()
        {
            InitializeComponent();
        }
        public IzmeniVipNaRevijiForm(VIPBasic v)
        {
            InitializeComponent();
            vip = v;
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            txtMbr.Text = vip.Mbr;
            txtIme.Text = vip.Ime;
            txtPrezime.Text = vip.Prezime;
            dateTimePicker1.Value = (DateTime)vip.DatRodj;
            txtPol.Text = vip.Pol.ToString();
            txtZanimanje.Text = vip.Zanimanje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vip.Mbr = txtMbr.Text;
            vip.Ime = txtIme.Text;
            vip.Prezime = txtPrezime.Text;
            vip.Pol = Char.Parse(txtPol.Text);
            vip.Zanimanje = txtZanimanje.Text;
            vip.DatRodj = dateTimePicker1.Value;
            
            //radnik.Sef = false;

            DTOManager.IzmeniVipNaReviji(vip);
            MessageBox.Show("Uspesno ste izmenili podatke o VIP-u!");
            this.Close();
        }
    }
}
