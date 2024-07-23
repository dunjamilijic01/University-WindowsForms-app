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
    public partial class AktivneZemljeForm : Form
    {
        int pib;
        public AktivneZemljeForm()
        {
            InitializeComponent();
        }
        public AktivneZemljeForm(int pib)
        {
            InitializeComponent();
            this.pib = pib;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<PoslujeUBasic> p = DTOManager.vratiPoslujeU(pib);
            foreach (PoslujeUBasic pb in p)
            {
                ListViewItem item = new ListViewItem(new string[] { pb.Id.ToString(),pb.AgencijaPIB.ToString(),pb.NazivZemlje });
                listView1.Items.Add(item);

            }
            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zemlju koju zelite da obrisete!");
                return;
            }

            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu zemlju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiZemlju(id);
                MessageBox.Show("Brisanje zemlje je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajZemljuForm formaDodaj = new DodajZemljuForm(pib);
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zemlju koju zelite da izmenite!");
                return;
            }

            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            PoslujeUBasic p = DTOManager.vratiPosluje(id);
            IzmeniZemljuForm formaDodaj = new IzmeniZemljuForm(p);
            formaDodaj.ShowDialog();
            

            this.popuniPodacima();
        }
    }
}
