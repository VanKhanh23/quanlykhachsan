using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class khachhangDAO
    {
        static SqlConnection con;
        public DataTable hienthikhachhang()
        {
            SqlConnection cnn = ketnoi.Get();
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            SqlCommand cmd = new SqlCommand("hienthikhachhang", cnn);
            // Khai báo kiểu thực thi là Thực thi thủ tục
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public bool them_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich)
        {
            string ngaySinhFormat = ngaySinh.ToString("yyyy-MM-dd");
            string sTruyVan = string.Format(@"INSERT INTO khachhang VALUES ('{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", tenKhachHang, ngaySinhFormat, gioiTinh, chungMinhNhanDan, diaChi, soDienThoai, quocTich);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;
        }
        public void xoa_nhanvien(int maKhachHang)
        {

            SqlConnection cnn = ketnoi.Get();
            SqlCommand cmd = new SqlCommand("xoa_khachhang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("maKhachHang", maKhachHang);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public bool sua_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich, int maKhachHang)
        {
            string ngaySinhFormat = ngaySinh.ToString("yyyy-MM-dd");
            string sTruyVan = string.Format(@"update khachhang set tenKhachHang=N'{0}',ngaySinh='{1}', gioiTinh='{2}', chungMinhNhanDan='{3}', diaChi='{4}', soDienThoai='{5}', quocTich='{6}' where maKhachHang=N'{7}'", tenKhachHang, ngaySinhFormat, gioiTinh, chungMinhNhanDan, diaChi, soDienThoai, quocTich, maKhachHang);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;
        }

    }
}
