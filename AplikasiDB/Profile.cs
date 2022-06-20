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
    public partial class Profile : Form
    {
        private readonly DbTaEntities _Ta;
        private string vUser;
        private string vRole;

        public Profile(string vUser, string vRole)
        {
            InitializeComponent();
            _Ta = new DbTaEntities();
            this.vUser = vUser;
            this.vRole = vRole;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vPassLama = textBox1.Text;
            string vPassBaru = textBox2.Text;
            string vPassConfirm = textBox3.Text;
            //var result;

            if (vRole == "mhs")
            {
                var result = _Ta.tbl_mhs.FirstOrDefault(q => q.email == vUser);
                if (vPassLama != result.password.Trim())
                {
                    MessageBox.Show("Password lama salah.");
                } else if (vPassBaru != vPassConfirm)
                {
                    MessageBox.Show("Konfirmasi password tidak sesuai.");
                }
                else
                {
                    result.password = vPassBaru;
                    _Ta.SaveChanges();
                    MessageBox.Show("Password berhasil disimpan.");
                    var formDashboard = new Dashboard(vUser, vRole);
                    this.Close();
                    formDashboard.ShowDialog();

                }
            }
            else
            {
                var result = _Ta.tbl_dosen.FirstOrDefault(q => q.email == vUser);
                if (vPassLama != result.password.Trim())
                {
                    MessageBox.Show("Password lama salah.");
                }
                else if (vPassBaru != vPassConfirm)
                {
                    MessageBox.Show("Konfirmasi password tidak sesuai.");
                }
                else
                {
                    result.password = vPassBaru;
                    _Ta.SaveChanges();
                    MessageBox.Show("Password berhasil disimpan.");
                    this.Close();
                }
            }
            
        }
    }
}
