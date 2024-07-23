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
    public partial class DodajPostojecegKreatora : Form
    {
        ModnaRevijaBasic revija;
        KreatorBasic kreator;
        public DodajPostojecegKreatora()
        {
            InitializeComponent();
        }
        public DodajPostojecegKreatora(ModnaRevijaBasic r)
        {
            InitializeComponent();
            revija = r;
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            List<KreatorBasic> listaKreatora = DTOManager.vratiSveKreatore();
            foreach (KreatorBasic k in listaKreatora)
                comboBox1.Items.Add(k.id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizujeBasic org = new OrganizujeBasic();
            kreator = DTOManager.vratiKreatora((int)(comboBox1.SelectedItem));
            org.KreatorOrganizuje = kreator;
            org.OrganizujeRevija = revija;
           
            DTOManager.dodajPostojecegKreatora(org);
            MessageBox.Show("Uspesno ste dodali postojeceg kreatora reviji!");
            this.Close();
        }
    }
}
