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
using DTO;

namespace quanlykhachsan
{
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
        }
        int temp;
        private void hienthi()
        {
            nhanvienBUS pbll = new nhanvienBUS();
            dataGridView1.DataSource = pbll.hienthinhanvien();
        }
        private void trangthai(bool t)
        {
          //  txtmanv.Enabled = t;
            txttennv.Enabled = t;
            txtscm.Enabled = t;
            txtsdt.Enabled = t;
            txtdiachi.Enabled = t;
            dtngaysinh.Enabled = t;
            dtngayvaolam.Enabled = t;
            cbgioitinh.Enabled = t;

        }

        private void frm_load(object sender, EventArgs e)
        {
            //hienthi();
            nhanvienBUS pbll = new nhanvienBUS();
            dataGridView1.DataSource = pbll.hienthinhanvien();
            trangthai(true);
     
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txtmanv.Text = row.Cells["maNhanVien"].Value.ToString();
            txttennv.Text = row.Cells["hoTen"].Value.ToString();
            txtscm.Text = row.Cells["soChungMinh"].Value.ToString();
            txtsdt.Text = row.Cells["soDienThoai"].Value.ToString();
            txtdiachi.Text = row.Cells["diaChi"].Value.ToString();
            cbgioitinh.Text = row.Cells["gioiTinh"].Value.ToString();
            dtngaysinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value.ToString());
            dtngayvaolam.Value = Convert.ToDateTime(row.Cells["ngayVaoLam"].Value.ToString());
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtdiachi.Text == "" || txtscm.Text == "" || txtsdt.Text == "" || txttennv.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "Thông báo");
                return;
            }

            nhanvienDTO nhanvien = new nhanvienDTO();

            nhanvien.hoTen = txttennv.Text;
            nhanvien.ngayVaoLam = DateTime.Parse(dtngayvaolam.Text);
            nhanvien.ngaySinh = DateTime.Parse(dtngaysinh.Text);
            nhanvien.soChungMinh = txtscm.Text;
            nhanvien.diaChi = txtdiachi.Text;
            nhanvien.soDienThoai = txtsdt.Text;
            nhanvien.gioiTinh = travegioitinh();


            nhanvienBUS nvBUS = new nhanvienBUS();
            if (nvBUS.them_nhanvien(nhanvien.hoTen, nhanvien.gioiTinh, nhanvien.ngaySinh, nhanvien.soChungMinh, nhanvien.diaChi, nhanvien.soDienThoai, nhanvien.ngayVaoLam) == false)
            {
                MessageBox.Show("Không thêm được.", "Thông báo");
                return;
            }

            hienthi();
            MessageBox.Show("Đã thêm nhân viên.", "Thông báo");

        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            nhanvienDTO nhanvien = new nhanvienDTO();

            nhanvien.maNhanVien = int.Parse(txtmanv.Text);
            nhanvien.hoTen = txttennv.Text;
            nhanvien.diaChi = txtdiachi.Text;
            nhanvien.soChungMinh = txtscm.Text;
            nhanvien.gioiTinh = travegioitinh();
            nhanvien.soDienThoai = txtsdt.Text;
            nhanvien.ngaySinh = DateTime.Parse(dtngaysinh.Text);
            nhanvien.ngayVaoLam = DateTime.Parse(dtngayvaolam.Text);

            nhanvienBUS nvBUS = new nhanvienBUS();
            if (nvBUS.sua_nhanvien(nhanvien.hoTen, nhanvien.gioiTinh, nhanvien.ngaySinh, nhanvien.soChungMinh, nhanvien.diaChi, nhanvien.soDienThoai, nhanvien.ngayVaoLam, nhanvien.maNhanVien) == false)
            {
                MessageBox.Show("Không sửa được.", "Thông báo");
                return;
            }

            hienthi();
            MessageBox.Show("Đã sửa nhân viên.", "Thông báo");

        }
        private bool travegioitinh()
        {
            if (cbgioitinh.Text == "Nam")
                return true;
            else
                return false;   
        }


        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            nhanvienBUS nvBLL = new nhanvienBUS();
            DialogResult luu = MessageBox.Show("Bạn chắc chắn xóa??", "Thông báo thêm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (luu == DialogResult.Yes)
            {
                nvBLL.xoa_nhanvien(int.Parse(txtmanv.Text));
                hienthi();
            }
        }



        private void txtmanv_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
