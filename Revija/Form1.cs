using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Revija.Entiteti;
using Revija.Forme;

namespace Revija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnModneRevije_Click(object sender, EventArgs e)
        {
            ModneRevijeForm forma = new ModneRevijeForm();
            forma.ShowDialog();
        }

        private void btnModniKreatori_Click(object sender, EventArgs e)
        {
            ModniKreatoriForm forma = new ModniKreatoriForm();
            forma.ShowDialog();
        }

        private void btnManekeni_Click(object sender, EventArgs e)
        {
            ManekeniForm forma = new ManekeniForm();
            forma.ShowDialog();
        }
    }
}
