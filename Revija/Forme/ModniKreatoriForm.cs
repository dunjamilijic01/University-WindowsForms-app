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
    public partial class ModniKreatoriForm : Form
    {
        public ModniKreatoriForm()
        {
            InitializeComponent();
        }

        private void ModniKreatoriForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KreatorBasic> kreatori = DTOManager.vratiSveKreatore();

            foreach (KreatorBasic k in kreatori)
            {
                ListViewItem item = new ListViewItem(new string[] { k.id.ToString(),k.ime,k.prezime,k.zemljaPorekla,k.nazivKuce });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajKreatoraForm formaDodaj = new DodajKreatoraForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreatora cije podatke zelite da izmenite!");
                return;
            }

            int idKreatora = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            KreatorBasic kb = DTOManager.vratiKreatora(idKreatora);

            IzmeniKreatoraForm formaUpdate = new IzmeniKreatoraForm(kb);
            formaUpdate.ShowDialog();

            this.popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreatora koga zelite da obrisete!");
                return;
            }

            int idKreatora = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog kreatora?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKreatora(idKreatora);
                MessageBox.Show("Brisanje kreatora je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }
    }
}
