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
    public partial class Form3 : Form
    {
        private readonly DbTaEntities _Ta;
        public Form3()
        {
            InitializeComponent();
            _Ta = new DbTaEntities();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vUser = textBox1.Text.Trim().ToLower();
            string vPass = textBox2.Text.Trim();

            var resultMhs = _Ta.tbl_mhs.FirstOrDefault(q => q.email.ToLower() == vUser);
            if (resultMhs == null)
            {
                var resultDosen = _Ta.tbl_dosen.FirstOrDefault(q => q.email == vUser);
                if (resultDosen == null)
                {
                    MessageBox.Show("Username/Password salah!");
                }
                else if (resultDosen.password.Trim() == vPass)
                {
                    MessageBox.Show("Login Berhasil!");
                    var formDashboard = new Dashboard(vUser, "dosen");
                    Hide();
                    formDashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username/Password salah! ");
                }
            }
            else
            {
                if (resultMhs.password.Trim() == vPass)
                {
                    MessageBox.Show("Login Berhasil!");
                    var formDashboard = new Dashboard(vUser, "mhs");
                    Hide();
                    formDashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username/Password salah! ");
                }
            }
        }

    }
}
