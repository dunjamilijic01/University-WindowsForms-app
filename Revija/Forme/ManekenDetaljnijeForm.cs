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
    public partial class ManekenDetaljnijeForm : Form
    {
        ProfesionalniModelBasic model;
        public ManekenDetaljnijeForm()
        {
            InitializeComponent();
        }
        public ManekenDetaljnijeForm(ProfesionalniModelBasic m)
        {
            InitializeComponent();
            model = m;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManekenDetaljnijeForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            lblMbr.Text = model.Mbr;
            lblIme.Text = model.Ime;
            lblPrezime.Text = model.Prezime;
            lblDat.Text = model.DatRodj.ToString();
            lblPol.Text = model.Pol.ToString();
            lblVisina.Text = model.Visina.ToString();
            lblTezina.Text = model.Tezine.ToString();
            lblOci.Text = model.BojaOciju;
            lblKosa.Text = model.BojaKose;
            lblKonf.Text = model.KonfBroj;
            lblAgencija.Text = DTOManager.vratiModnuAgenciju(model.AgencijaPIB).Naziv;

            listView1.Items.Clear();
            List<NaslovnaStranaBasic> podaci = DTOManager.vratiSveNaslovneStrane(model.Id);



            foreach (NaslovnaStranaBasic p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(),p.NazivCasopisa });
                listView1.Items.Add(item);

            }



            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModnaAgencijaForm formaDodaj = new ModnaAgencijaForm(this.model);
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite casopis koji zelite da obrisete!");
                return;
            }

            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani casopis?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiStranicu(id);
                MessageBox.Show("Brisanje casopisa je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CasopisDodajForm formaDodaj = new CasopisDodajForm(model);
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite naslovnu stranu cije podatke zelite da izmenite!");
                return;
            }

            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            NaslovnaStranaBasic str = DTOManager.vratiNaslovnuStranu(id);

            IzmeniNaslovnuStranuForm formaUpdate = new IzmeniNaslovnuStranuForm(str);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }
    }
}
