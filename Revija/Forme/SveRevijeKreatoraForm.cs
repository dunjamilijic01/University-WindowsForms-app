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
    public partial class SveRevijeKreatoraForm : Form
    {
        KreatorBasic kreator;
        public int br;
        public SveRevijeKreatoraForm()
        {
            InitializeComponent();
        }
        public SveRevijeKreatoraForm(KreatorBasic k)
        {
            InitializeComponent();
            kreator = k;
        }

        private void SveRevijeKreatoraForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();

        }
        public void popuniPodacima()
        {
            br = 0;
            lblNaslov.Text = "PREGLED SVIH REVIJA KREATORA " + kreator.ime + " " + kreator.prezime;
            listView1.Items.Clear();
            List<ModnaRevijaBasic> revije = DTOManager.vratiSveRevijeKreatora(kreator.id);
            foreach (ModnaRevijaBasic m in revije)
            {
                ListViewItem item = new ListViewItem(new string[] { m.RbrRevije.ToString(),m.Naziv,m.MestoOdrzavanja,m.DatumVremeOdrzavanja.ToString(), });
                listView1.Items.Add(item);
                this.br++;
            }

            lblBrojRevija.Text = this.br.ToString();
            listView1.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite reviju koju zelite da obrisete!");
                return;
            }

            int idRevije = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu reviju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiReviju(idRevije);
                MessageBox.Show("Brisanje revije je uspesno obavljeno!");
                this.popuniPodacima();
            };
        }
    }
}
