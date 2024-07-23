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
    public partial class ModneRevijeForm : Form
    {
        public ModneRevijeForm()
        {
            InitializeComponent();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (listaRevije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite modnu reviju cije podatke zelite da izmenite!");
                return;
            }
            int rbr = Int32.Parse(listaRevije.SelectedItems[0].SubItems[0].Text);
            ModnaRevijaBasic mb = DTOManager.vratiReviju(rbr);

            IzmeniRevijuForm formaIzmeni = new IzmeniRevijuForm(mb);
            formaIzmeni.ShowDialog();

            this.popuniPodacima();
        }

        private void btnManekeni_Click(object sender, EventArgs e)
        {
            if (listaRevije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite reviju cije manekene zelite da vidite!");
                return;
            }

            int rbr = Int32.Parse(listaRevije.SelectedItems[0].SubItems[0].Text);
            ModnaRevijaBasic r = DTOManager.vratiReviju(rbr);
            ManekeniNaRevijiForm forma = new ManekeniNaRevijiForm(r);
            forma.ShowDialog();
        }

        private void ModneRevijeForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listaRevije.Items.Clear();
            List<ModnaRevijaPregled> podaci = DTOManager.vratiSveRevije();

            foreach (ModnaRevijaPregled m in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { m.RbrRevije.ToString(), m.Naziv, m.MestoOdrzavanja, m.DatumVremeOdrzavanja.ToString() });
                listaRevije.Items.Add(item);
            }
            listaRevije.Refresh();
        }

        private void btnDodajReviju_Click(object sender, EventArgs e)
        {
            DodajRevijuForm formaDodaj = new DodajRevijuForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiReviju_Click(object sender, EventArgs e)
        {
            if (listaRevije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite modnu reviju koju zelite da obrisete!");
                return;
            }

            int rbr = Int32.Parse(listaRevije.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu prodavnicu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if(result==DialogResult.OK)
            {
                DTOManager.obrisiReviju(rbr);
                MessageBox.Show("Brisanje modne revije je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void btnVip_Click(object sender, EventArgs e)
        {
            if (listaRevije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite reviju cije VIP zelite da vidite!");
                return;
            }

            int rbr = Int32.Parse(listaRevije.SelectedItems[0].SubItems[0].Text);
            ModnaRevijaBasic r = DTOManager.vratiReviju(rbr);
            VipNaRevijiForm forma = new VipNaRevijiForm(r);
            forma.ShowDialog();
        }

        private void btnModniKreatori_Click(object sender, EventArgs e)
        {
            if (listaRevije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite reviju cije kreatore zelite da vidite!");
                return;
            }

            int rbr = Int32.Parse(listaRevije.SelectedItems[0].SubItems[0].Text);
            ModnaRevijaBasic r = DTOManager.vratiReviju(rbr);
            KreatoriNaRevijiForm forma = new KreatoriNaRevijiForm(r);
            forma.ShowDialog();
        }
    }
}
