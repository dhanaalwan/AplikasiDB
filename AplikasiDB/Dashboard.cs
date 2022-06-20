using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiDB
{
    public partial class Dashboard : Form
    {
        private readonly DbTaEntities _Ta;
        private string vUser;
        private string vRole;

        public Dashboard(string vUser, string vRole)
        {
            InitializeComponent();
            this.vUser = vUser;
            this.vRole = vRole;
        }

        private void bALKToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Selamat datang "+vUser);
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProfile = new Profile(vUser, vRole);
            Hide();
            formProfile.ShowDialog();
        }
    }
}
