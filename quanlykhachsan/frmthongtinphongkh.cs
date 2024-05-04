using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace quanlykhachsan
{
    public partial class frmthongtinphongkh : Form
    {
        public frmthongtinphongkh()
        {
            InitializeComponent();
        }

        private void frm_load(object sender, EventArgs e)
        {
            phongBUS pbll = new phongBUS();
            dataGridView1.DataSource = pbll.hienthithongtinphong();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdangnhap frm = new frmdangnhap();
            frm.Show();

        }
    }
}
