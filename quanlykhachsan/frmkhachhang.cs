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
    public partial class frmkhachhang : Form
    {
        public frmkhachhang()
        {
            InitializeComponent();
        }
        int temp;
        private void hienthi()
        {
            khachhangBUS pbll = new khachhangBUS();
            dataGridView1.DataSource = pbll.hienthikhachhang();
        }
        private void trangthai(bool t)
        {
           // txtmakhachhang.Enabled = t;
            txttenkh.Enabled = t;
            txtcmt.Enabled = t;
            txtsdt.Enabled = t;
            txtdiachi.Enabled = t;
            dtngaysinh.Enabled = t;
            cbquoctich.Enabled = t;
            cbgiotinhkh.Enabled = t;
        }

        private void frm_load(object sender, EventArgs e)
        {
            hienthi();
            trangthai(true);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txtmakhachhang.Text = row.Cells["maKhachHang"].Value.ToString();
            txttenkh.Text = row.Cells["tenKhachHang"].Value.ToString();
            txtcmt.Text = row.Cells["chungMinhNhanDan"].Value.ToString();
            txtsdt.Text = row.Cells["soDienThoai"].Value.ToString();
            txtdiachi.Text = row.Cells["diaChi"].Value.ToString();
            cbquoctich.Text = row.Cells["quocTich"].Value.ToString();
            cbgiotinhkh.Text = row.Cells["gioiTinh"].Value.ToString();
            dtngaysinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value.ToString());
        }
        private bool travegioitinh()
        {
            if (cbgiotinhkh.Text == "Nam")
                return true;
            else
                return false;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            khachhangDTO khachhang = new khachhangDTO();

            khachhang.maKhachHang = int.Parse(txtmakhachhang.Text);
            khachhang.tenKhachHang = txttenkh.Text;
            khachhang.diaChi = txtdiachi.Text;
            khachhang.chungMinhNhanDan = txtcmt.Text;
            khachhang.quocTich = cbquoctich.Text;
            khachhang.gioiTinh = travegioitinh();
            khachhang.ngaySinh = DateTime.Parse(dtngaysinh.Text);

            khachhangBUS khBUS = new khachhangBUS();
            if (khBUS.sua_khachhang(khachhang.tenKhachHang, khachhang.ngaySinh, khachhang.gioiTinh, khachhang.chungMinhNhanDan, khachhang.diaChi, khachhang.soDienThoai, khachhang.quocTich, khachhang.maKhachHang) == false)
            {
                MessageBox.Show("Không sửa được.", "Thông báo");
                return;
            }

            hienthi();
            MessageBox.Show("Đã sửa khách hàng.", "Thông báo");

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            khachhangBUS khBLL = new khachhangBUS();
            DialogResult luu= MessageBox.Show("Bạn chắc chắn xóa??", "Thông báo thêm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(luu==DialogResult.Yes)
            {
                
               khBLL.xoa_khachhang(int.Parse(txtmakhachhang.Text));
              hienthi();
            }
        }



        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txttenkh.Text == "" || txtsdt.Text == "" || txtdiachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "Thông báo");
                return;
            }

            khachhangDTO khachhang = new khachhangDTO();
            khachhang.tenKhachHang = txttenkh.Text;
            khachhang.diaChi = txtdiachi.Text;
            khachhang.chungMinhNhanDan = txtcmt.Text;
            khachhang.quocTich = cbquoctich.Text;
            khachhang.gioiTinh = travegioitinh();
            khachhang.ngaySinh = DateTime.Parse(dtngaysinh.Text);

            khachhangBUS khBUS = new khachhangBUS();
            if (khBUS.them_khachhang(khachhang.tenKhachHang, khachhang.ngaySinh, khachhang.gioiTinh, khachhang.chungMinhNhanDan, khachhang.diaChi, khachhang.soDienThoai, khachhang.quocTich) == false)
            {
                MessageBox.Show("Không thêm được.", "Thông báo");
                return;
            }

            hienthi();
            MessageBox.Show("Đã thêm khách hàng.", "Thông báo");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtmakhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbgiotinhkh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
