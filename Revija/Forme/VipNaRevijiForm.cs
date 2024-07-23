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
    public partial class VipNaRevijiForm : Form
    {
        ModnaRevijaBasic revija;
        public VipNaRevijiForm()
        {
            InitializeComponent();
        }
        public VipNaRevijiForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
        }

        private void VipNaRevijiForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listaVIP.Items.Clear();
            List<VipPregled> podaci = DTOManager.vratiSveVipRevije( revija.RbrRevije);



            foreach (VipPregled v in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { v.Id.ToString(),v.Ime,v.Prezime,v.Zanimanje });
                listaVIP.Items.Add(item);

            }
            listaVIP.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajVipNaRevijiForm forma = new DodajVipNaRevijiForm(revija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listaVIP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite VIP cije podatke zelite da izmenite!");
                return;
            }

            int idVip = Int32.Parse(listaVIP.SelectedItems[0].SubItems[0].Text);
            VIPBasic vb = DTOManager.vratiVip(idVip);

            IzmeniVipNaRevijiForm formaUpdate = new IzmeniVipNaRevijiForm(vb);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listaVIP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite VIP koga zelite da obrisete!");
                return;
            }

            int idVip = Int32.Parse(listaVIP.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog VIP-a?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiVipNaReviji(idVip);
                MessageBox.Show("Brisanje Vipa je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listaVIP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite VIP koga zelite da pregledate!");
                return;
            }

            int idVip = Int32.Parse(listaVIP.SelectedItems[0].SubItems[0].Text);
            VIPBasic vb = DTOManager.vratiVip(idVip);

            GostujeNeUcestvujeForm formaUpdate = new GostujeNeUcestvujeForm(vb);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }
    }
}
