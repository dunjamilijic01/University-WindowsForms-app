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
    public partial class DodeliRevijuForm : Form
    {
        public VIPBasic vip;
        public DodeliRevijuForm()
        {
            InitializeComponent();
        }
        public DodeliRevijuForm(VIPBasic v)
        {
            InitializeComponent();
            vip = v;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rbr = Convert.ToInt32(numericUpDown1.Value);
            DTOManager.dodeliRevijuVipu(rbr,vip.Id);
            MessageBox.Show("Revija je uspesno dodata");
        }
    }
}
