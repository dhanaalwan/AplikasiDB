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
    public partial class Form2 : Form
    {
        private readonly DbTaEntities _Ta;
        public Form2()
        {
            InitializeComponent();
            _Ta = new DbTaEntities();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vNip = textBox1.Text;
            string vNama = textBox2.Text;
            string vPass = textBox3.Text;
            string vEmail = "EMAIL";

            var newDosen = new tbl_dosen(vNip, vNama, vPass, vEmail);
            _Ta.tbl_dosen.Add(newDosen);
            _Ta.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dosen = _Ta.tbl_dosen.FirstOrDefault(q => q.nip == textBox1.Text);
            string nama = dosen.nama;
            textBox2.Text = nama;
        }
    }
}
