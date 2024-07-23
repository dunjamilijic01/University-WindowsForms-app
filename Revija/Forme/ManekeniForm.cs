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
    public partial class ManekeniForm : Form
    {
        public ManekeniForm()
        {
            InitializeComponent();
        }

        private void ManekeniForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<ProfesionalniModelPregled> podaci = DTOManager.vratiSveManekene();



            foreach (ProfesionalniModelPregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(),p.Ime,p.Prezime,p.Mbr});
                listView1.Items.Add(item);

            }



            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajManekenaForm formaDodaj = new DodajManekenaForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite modela kog zelite da obrisete!");
                return;
            }

            int idModel = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog modela?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiManekena(idModel);
                MessageBox.Show("Brisanje modela je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite modela cije podatke zelite da izmenite!");
                return;
            }

            int idModela = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ProfesionalniModelBasic mb = DTOManager.vratiManekena(idModela);

            IzmeniManekenaForm formaUpdate = new IzmeniManekenaForm(mb);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite modela cije podatke zelite detaljnije da pregledate!");
                return;
            }

            int idModela = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ProfesionalniModelBasic mb = DTOManager.vratiManekena(idModela);

            ManekenDetaljnijeForm formaUpdate = new ManekenDetaljnijeForm(mb);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }
    }
}
