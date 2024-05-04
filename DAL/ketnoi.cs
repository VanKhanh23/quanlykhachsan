using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ketnoi
    {
        public static SqlConnection Get()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=LAPTOP-BSGEG72V;Initial Catalog=quanlykhachsan;Integrated Security=True";
            cnn.Open();
            return cnn;
        }
        public static DataTable TruyVanLayDuLieu(string sTruyVan, SqlConnection KetNoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, KetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool TruyVanKhongLayDuLieu(string sTruyVan, SqlConnection
        KetNoi)
        {
            SqlCommand cm = new SqlCommand(sTruyVan, KetNoi);
            cm.ExecuteNonQuery();
            return true;
        }
        public static void DongKetNoi(SqlConnection KetNoi)
        {
            KetNoi.Close();
        }
    }
}
