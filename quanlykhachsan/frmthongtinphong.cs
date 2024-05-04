using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace quanlykhachsan
{
    public partial class frmthongtinphong : Form
    {
        public frmthongtinphong()
        {
   
            InitializeComponent();
        }
        private void hienthi()
        {
            phongBUS pbll = new phongBUS();
            GridView.DataSource = pbll.hienthithongtinphong();
        }
        private void trangthai(bool t)
        {
            txtphong.Enabled = t;
            txtdongiaphong.Enabled = t;
            cbloaiphong.Enabled = t;
            cbtinhtrang.Enabled = t;
        }
        private void frm_load(object sender, EventArgs e)
        {
            hienthi();
            trangthai(true);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = GridView.Rows[e.RowIndex];
            txtphong.Text = row.Cells["maPhong"].Value.ToString();
            txtdongiaphong.Text = row.Cells["donGia"].Value.ToString();
            cbloaiphong.Text= row.Cells["loaiPhong"].Value.ToString();          
            cbtinhtrang.Text =row.Cells["tinhTrang"].Value.ToString();           
        }

        private void btnthemphong_Click(object sender, EventArgs e)
        {
            trangthai(true);

            if (txtphong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "Thông báo");
                return;
            }
            
            phongDTO phong = new phongDTO();
            phong.maPhong = txtphong.Text;
            phong.tinhTrang = cbtinhtrang.Text == "Bận";
            phong.loaiPhong = cbloaiphong.Text;
            phongBUS phBUS = new phongBUS();
            if (phBUS.them_phong(phong.maPhong, phong.tinhTrang, phong.loaiPhong) == false)
            {
                MessageBox.Show("Không thêm được.", "Thông báo");
                return;
            }

            hienthi();
            MessageBox.Show("Đã thêm phòng.", "Thông báo");

        }

        private void btnsuaphong_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            phongDTO phong = new phongDTO();

            phong.maPhong = txtphong.Text;
            phong.loaiPhong = cbloaiphong.Text;
            phong.tinhTrang = cbtinhtrang.Text == "Bận";

            phongBUS phBUS = new phongBUS();
            if (phBUS.sua_phong (phong.maPhong, phong.tinhTrang, phong.loaiPhong) == false)
            {
                MessageBox.Show("Không sửa được.", "Thông báo");
                return;
            }

            hienthi();
            MessageBox.Show("Đã sửa phòng.", "Thông báo");
        }

        private void btnxoaphong_Click(object sender, EventArgs e)
        {
            phongBUS pBLL = new phongBUS();
            DialogResult luu = MessageBox.Show("Bạn chắc chắn xóa??", "Thông báo thêm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (luu == DialogResult.Yes)
            {
                bool result = pBLL.xoa_phong(txtphong.Text);
                if (result)
                {
                    MessageBox.Show("Xóa phòng thành công", "Thông báo");
                    hienthi();
                } else
                {
                    MessageBox.Show("Xóa phòng thất bại", "Thông báo");
                }
            }
        }

        private void btnluuphong_Click(object sender, EventArgs e)
        {

        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnthoatphong_Click(object sender, EventArgs e)
        {

        }

        private void txtphong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtdongiaphong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbtinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
