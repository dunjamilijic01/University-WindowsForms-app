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
    public partial class KreatoriNaRevijiForm : Form
    {
        ModnaRevijaBasic revija;
        public KreatoriNaRevijiForm()
        {
            InitializeComponent();
        }
        public KreatoriNaRevijiForm(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            List<KreatorPregled> podaci = DTOManager.vratiKretoreRevije(revija.RbrRevije);



            foreach (KreatorPregled k in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { k.id.ToString(),k.ime,k.prezime,k.zemljaPorekla,k.nazivKuce });
                listView1.Items.Add(item);

            }



            listView1.Refresh();
        }

        private void KreatoriNaRevijiForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            if (revija.PrvaZajednickaRevija == 'Y')

                lblOdgovor.Text = "DA";
            else
                lblOdgovor.Text = "NE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreatora koga zelite da uklonite!");
                return;
            }

            int idKreatora = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da uklonite izabranog kreatora";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ukloniKreatoraSaRevije(idKreatora,revija.RbrRevije);
                MessageBox.Show("Uklonjen kreator");
                this.popuniPodacima();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajKreatoraRevijiForm formaDodaj = new DodajKreatoraRevijiForm(revija);
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DodajPostojecegKreatora forma = new DodajPostojecegKreatora(revija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kreatora cije revije zelite da pregledate");
                return;
            }

            int idKreatora = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            SveRevijeKreatoraForm forma = new SveRevijeKreatoraForm(DTOManager.vratiKreatora(idKreatora));
            forma.ShowDialog();
            popuniPodacima();
        }
    }
}
