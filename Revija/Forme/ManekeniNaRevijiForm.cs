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
    public partial class ManekeniNaRevijiForm : Form
    {
        ModnaRevijaBasic revija;
        public ManekeniNaRevijiForm()
        {
            InitializeComponent();
        }
        public ManekeniNaRevijiForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
        }

        private void ManekeniNaRevijiForm_Load(object sender, EventArgs e)
        {
            this.Text = "MODNA REVIJA " + revija.Naziv.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            //String pom;
            this.listaManekena.Items.Clear();
            List<ManekenPregled> manekeni = DTOManager.vratiSveManekeneRevije(revija.RbrRevije);
            foreach (ManekenPregled m in manekeni)
            {
                ListViewItem item = new ListViewItem(new string[] { m.Ime, m.Prezime,m.Visina.ToString(),m.Tezine.ToString(),m.BojaOciju,m.BojaKose,m.KonfBroj,m.Mbr,m.Id.ToString()});
                this.listaManekena.Items.Add(item);

            }
            this.listaManekena.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajProfModelaRevijiForm forma = new DodajProfModelaRevijiForm(revija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajVipNaRevijiForm forma = new DodajVipNaRevijiForm(revija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listaManekena.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite manekena koga zelite da obrisete!");
                return;
            }

            int idManeken = Int32.Parse(listaManekena.SelectedItems[0].SubItems[8].Text);
            string poruka = "Da li zelite da obrisete izabranog manekena?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiManekena(idManeken);
                MessageBox.Show("Brisanje manekena je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listaManekena.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite manekena cije podatke zelite da izmenite!");
                return;
            }

            int idManekena = Int32.Parse(listaManekena.SelectedItems[0].SubItems[8].Text);
            ProfesionalniModelBasic pm = DTOManager.vratiManekena(idManekena);

            IzmeniManekenaNaRevijiForm formaUpdate = new IzmeniManekenaNaRevijiForm(pm);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }
    }
}
