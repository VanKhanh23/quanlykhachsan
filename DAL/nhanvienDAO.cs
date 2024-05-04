using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
   public class nhanvienDAO
    {
        static SqlConnection con;
        public DataTable hienthitatcanhanvien()
        {
            SqlConnection cnn = ketnoi.Get();
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            SqlCommand cmd = new SqlCommand("hienthitatcanhanvien", cnn);
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
        public bool them_nhanvien(string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam)
        {
            string ngaySinhFormat = ngaySinh.ToString("yyyy-MM-dd");
            string ngayVaoLamFormat = ngayVaoLam.ToString("yyyy-MM-dd");
            string sTruyVan = string.Format(@"INSERT INTO nhanvien VALUES ('{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", hoTen, gioiTinh,ngaySinhFormat, soChungMinh, diaChi, soDienThoai, ngayVaoLamFormat);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;
        }
            public void xoa_nhanvien(int maNhanVien)
        {

            SqlConnection cnn = ketnoi.Get();
            SqlCommand cmd = new SqlCommand("xoa_nhanvien", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("maNhanVien", maNhanVien);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public bool sua_nhanvien(string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam, int maNhanVien)
        {
            string ngaySinhFormat = ngaySinh.ToString("yyyy-MM-dd");
            string ngayVaoLamFormat = ngayVaoLam.ToString("yyyy-MM-dd");
            string sTruyVan = string.Format(@"update nhanvien set hoTen=N'{0}',gioiTinh='{1}', ngaySinh='{2}', soChungMinh='{3}', diaChi='{4}', soDienThoai='{5}', ngayVaoLam='{6}' where maNhanVien=N'{7}'", hoTen, gioiTinh, ngaySinhFormat, soChungMinh, diaChi, soDienThoai, ngayVaoLamFormat, maNhanVien);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;
        }
    
    }
}
