using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
   public class phongDAO
    {
        static SqlConnection con;
        public DataTable hienthithongtinphong()
        {
            SqlConnection cnn = ketnoi.Get();         
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            SqlCommand cmd = new SqlCommand("hienthiphong", cnn);
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
        public bool them_phong(string maPhong, bool tinhTrang, string loaiPhong)
        {

            string sTruyVan = string.Format(@"INSERT INTO phong VALUES ('{0}', N'{1}', N'{2}')", maPhong, tinhTrang, loaiPhong);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;

        }

        public bool xoa_phong(string maPhong)
        {

            string sTruyVan = string.Format(@"delete from phong where maPhong=N'{0}'", maPhong);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;

        }

        public bool sua_phong(string maPhong, bool tinhTrang, string loaiPhong)
        {

            string sTruyVan = string.Format(@"update phong set tinhTrang=N'{0}',loaiPhong='{1}' where maPhong=N'{2}'", tinhTrang, loaiPhong, maPhong);
            con = ketnoi.Get();
            bool kq = ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
            return kq;



        }


    }
}
