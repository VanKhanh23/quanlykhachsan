using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;

namespace BUS
{
   public class khachhangBUS
    {
        khachhangDAO khDAO = new khachhangDAO();
        public DataTable hienthikhachhang()
        {
            return khDAO.hienthikhachhang();
        }
        public bool them_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich)
        {
            
            return khDAO.them_khachhang(tenKhachHang, ngaySinh, gioiTinh, chungMinhNhanDan, diaChi, soDienThoai, quocTich);
        }
         public void xoa_khachhang(int maKhachHang)
        {
            khDAO.xoa_nhanvien(maKhachHang);

        }

        public bool sua_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich,int maKhachHang)
        {

            return khDAO.sua_khachhang(tenKhachHang, ngaySinh, gioiTinh, chungMinhNhanDan, diaChi, soDienThoai, quocTich, maKhachHang);
        }
    }
}
