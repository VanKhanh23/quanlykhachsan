using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
   public class phongBUS
    {
        phongDAO Stclr = new phongDAO();
        public DataTable hienthithongtinphong()
        {
            return Stclr.hienthithongtinphong();
        }
   
        public bool xoa_phong(string maPhong)
        {
            return Stclr.xoa_phong(maPhong);

        }

        public bool them_phong (string maPhong, bool tinhTrang, string loaiPhong)
        {
            return Stclr.them_phong(maPhong, tinhTrang, loaiPhong) ;

        }

        public bool sua_phong(string maPhong, bool tinhTrang, string loaiPhong)
        {
            return Stclr.sua_phong(maPhong, tinhTrang, loaiPhong);

        }

    }
}
