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
    public partial class ModnaAgencijaForm : Form
    {
        ProfesionalniModelBasic model;
        public ModnaAgencijaForm()
        {
            InitializeComponent();
        }
        public ModnaAgencijaForm(ProfesionalniModelBasic m)
        {
            InitializeComponent();
            model = m;
        }

        private void ModnaAgencijaForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listView1.Items.Clear();
            ModnaAgencijaBasic podaci = DTOManager.vratiModnuAgenciju(model.AgencijaPIB);

                ListViewItem item = new ListViewItem(new string[] { podaci.PIB.ToString(),podaci.Naziv,podaci.Sediste,podaci.Tip});
            if (podaci.Tip == "DOMACA")
                button3.Enabled = false;
                listView1.Items.Add(item);
            listView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            AktivneZemljeForm formaUpdate = new AktivneZemljeForm(model.AgencijaPIB);
            formaUpdate.ShowDialog();
            popuniPodacima();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IzmeniModnuAgencijuForm formaUpdate = new IzmeniModnuAgencijuForm(model.AgencijaPIB);
            formaUpdate.ShowDialog();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SveAgencijeForm formaUpdate = new SveAgencijeForm();
            formaUpdate.ShowDialog();
        }
    }
}
