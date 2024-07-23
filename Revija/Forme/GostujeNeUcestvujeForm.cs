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
    public partial class GostujeNeUcestvujeForm : Form
    {
        public VIPBasic vip;
        public GostujeNeUcestvujeForm()
        {
            InitializeComponent();
        }
        public GostujeNeUcestvujeForm(VIPBasic v)
        {
            InitializeComponent();
            vip = v;
        }

        private void GostujeNeUcestvujeForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            lblUpisi.Text = "VIP " + vip.Ime + " " + vip.Prezime + "\nprisustvovace prikazanim\nrevijama!";
        }

        public void popuniPodacima()
        {
            this.listView1.Items.Clear();
            List<ModnaRevijaPregled> revije = DTOManager.vratiSveRevijeSaVip(vip.Id);
            foreach (ModnaRevijaPregled m in revije)
            {
                ListViewItem item = new ListViewItem(new string[] { m.RbrRevije.ToString(),m.Naziv,m.MestoOdrzavanja,m.DatumVremeOdrzavanja.ToString() });
                this.listView1.Items.Add(item);

            }
            this.listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodeliRevijuForm forma = new DodeliRevijuForm(vip);
            forma.ShowDialog();
            this.popuniPodacima();
        }
    }
}
