using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class nhanvienBUS
    {
        nhanvienDAO nvDAO = new nhanvienDAO();
        public DataTable hienthinhanvien()
        {
            return nvDAO.hienthitatcanhanvien();
        }
        public bool them_nhanvien( 
            
            string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam)
        {
            return nvDAO.them_nhanvien( hoTen,  gioiTinh,  ngaySinh,  soChungMinh,  diaChi,  soDienThoai, ngayVaoLam);
        }
        public void xoa_nhanvien(int maNhanVien)
        {
            nvDAO.xoa_nhanvien(maNhanVien);

        }

        public bool sua_nhanvien(string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam, int maNhanVien)
        {

            return nvDAO.sua_nhanvien(hoTen, gioiTinh, ngaySinh, soChungMinh, diaChi, soDienThoai, ngayVaoLam, maNhanVien);
        }
    }
}

