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
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
           
        }
 
        
        private void hienthikhachhang()
        {
            khachhangBUS pbll = new khachhangBUS();
            dgkhachhang.DataSource = pbll.hienthikhachhang();
        }
        private void hienthiphong()
        {
            phongBUS pbll = new phongBUS();
            dtgvDanhSachphong.DataSource = pbll.hienthithongtinphong();
        }
        private void hienthitraphong()
        {
            thuephongBUS tpBLL = new thuephongBUS();
            dgtraphong.DataSource = tpBLL.hienthi_thuetheophong();
        }
        private void trangthai(bool t)
        {
            txtPhongtp.Enabled =t;
            dtTuNgaytp.Enabled = t;
            txtphongdt.Enabled = !t;
            dtngaydattruoc.Enabled = !t;
        }
        private void frm_load(object sender, EventArgs e)
        {
         
            hienthiphong();
            hienthikhachhang();
            dtTuNgaytp.Value = DateTime.Now;
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            frmmainquanlykhachsan.ActiveForm.Close();
            frmdangnhap frm = new frmdangnhap();
            frm.Show();
        }

        private void dgkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgkhachhang.Rows[e.RowIndex];
            txtmakhtp.Text = row.Cells["maKhachHang"].Value.ToString();
        }

        private void btThuePhongOK_Click(object sender, EventArgs e)
        {
            thuephongBUS tpBLL = new thuephongBUS();
            tpBLL.them_thuephong(int.Parse(txtmakhtp.Text.Trim()), dtTuNgaytp.Value, int.Parse(txtPhongtp.Text.Trim()));
            MessageBox.Show("thuê phòng thàng công", "Thông báo");
        }

        private void Tabphong_Click(object sender, EventArgs e)
        {
            hienthiphong();
            hienthitraphong();
        }

        private void bHuyBo_Click(object sender, EventArgs e)
        {
            txtPhongtp.Clear();
            txtphongdt.Clear();
            txtmakhtp.Clear();
        }

        private void checkBDatPhongTruoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBDatPhongTruoc.Checked == true)
                trangthai(false);
            else
                trangthai(true);
        }

        private void dtgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgtraphong.Rows[e.RowIndex];
            txtTPPhong.Text = row.Cells["maPhong"].Value.ToString();
            txtTPTenKH.Text = row.Cells["tenKhachHang"].Value.ToString();
            txtTPSoCMND.Text = row.Cells["chungMinhNhanDan"].Value.ToString();
            txtTPSoDT.Text = row.Cells["soDienThoai"].Value.ToString();
            txtTPDiaChi.Text = row.Cells["diaChi"].Value.ToString();
            txtdongiatp.Text = row.Cells["donGia"].Value.ToString();
            txtmathuephong.Text = row.Cells["donGia"].Value.ToString();
            dtngaysinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value.ToString());
            dttpngaybatdauthue.Value = Convert.ToDateTime(row.Cells["ngayDen"].Value.ToString());
           
        }
        private void thanhtoan()
        {
            TimeSpan Time = (dttpngayketthucthue.Value - dttpngaybatdauthue.Value);
            int TongSoNgay = Time.Days + 1;
            int ngaybatdau = dttpngaybatdauthue.Value.Day;
            int ngayketthuc = dttpngayketthucthue.Value.Day;

            if (ngaybatdau > ngayketthuc)/// vào từ sáng đén tối vẫn tính là 1 ngày
                MessageBox.Show("nhập sai ngày!! vui long nhập lại", "Thông báo");
            else
                txttongtien.Text = (TongSoNgay * int.Parse(txtdongiatp.Text)).ToString();
        }
        private void TPTinhTien_Click(object sender, EventArgs e)
        {
            thanhtoan();
           // thuephongBLL tpBLL = new thuephongBLL();
         //   tpBLL.tinhtien(dttpngayketthucthue.Value, float.Parse(txttongtien.Text.Trim()),int.Parse(txtmathuephong.Text.Trim()),int.Parse(txtTPPhong.Text.Trim()));
            hienthitraphong();
            MessageBox.Show("Số tiền phải trả là : "+txttongtien.Text,"Tổng tiền");  
        }

        private void cbTheoPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTheoPhong.Checked)
                TKTheoPhong.Enabled = true;
            else
            {
                TKTheoPhong.Enabled = false;
            }
        }

        private void cbTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTheoTen.Checked)
                TKTheoTen.Enabled = true;
            else
            {
                TKTheoTen.Enabled = false;
            }

        }

        private void cbThoiGian_CheckedChanged(object sender, EventArgs e)
        {

            if (cbTheoTen.Checked)
                TKTuNgay.Enabled = true;
            else
            {
                TKTuNgay.Enabled = false;
            }

        }

        private void cbTheoDT_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTheoDT.Checked)
                TKTheoSoDT.Enabled = true;
            else
            {
                TKTheoSoDT.Enabled = false;
            }


        }

        private void cbTheoMaKH_CheckedChanged(object sender, EventArgs e)
        {

            if (cbTheoMaKH.Checked)
                TKTheoMa.Enabled = true;
            else
            {
                TKTheoMa.Enabled = false;
            }
        }

        private void cbTheoCMND_CheckedChanged(object sender, EventArgs e)
        {

            if (cbTheoCMND.Checked)
                TKTheoCMND.Enabled = true;
            else
            {
                TKTheoCMND.Enabled = false;
            }

        }

        private void cbTheoDiaChi_CheckedChanged(object sender, EventArgs e)
        {

            if (cbTheoDiaChi.Checked)
                TKTheoDiaChi.Enabled = true;
            else
            {
                TKTheoDiaChi.Enabled = false;
            }

        }
    }
}
