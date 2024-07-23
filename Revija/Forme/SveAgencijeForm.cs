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
    public partial class SveAgencijeForm : Form
    {
        public SveAgencijeForm()
        {
            InitializeComponent();
        }

        private void SveAgencijeForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<ModnaAgencijaBasic> agencije = DTOManager.vratiSveAgencije();
            foreach (ModnaAgencijaBasic p in agencije)
            {
                ListViewItem item = new ListViewItem(new string[] { p.PIB.ToString(), p.Naziv,p.Sediste,p.DatumOsnivanja.ToString(),p.Tip });
                listView1.Items.Add(item);

            }



            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite Agenciju koju zelite da obrisete!");
                return;
            }

            int idAgencije = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu agenciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiAgenciju(idAgencije);
                MessageBox.Show("Brisanje agencije je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajAgencijuForm formaDodaj = new DodajAgencijuForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite Agenciju koju zelite da obrisete!");
                return;
            }

            int idAgencije = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ModnaAgencijaBasic m = DTOManager.vratiModnuAgenciju(idAgencije);
            IzmeniAgencijuForm formaDodaj = new IzmeniAgencijuForm(m);
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }
    }
}
