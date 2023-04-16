using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BUSS
{
    public class ThanhToanBUSS
    {
        public static void Them(string nguoinhan, string mataikhoan, string sdt, int tongtien)
        {

            using (var db = new ShopConnectionDB())
            {
                HoaDon hoadon = new HoaDon()
                {
                    NguoiDat = mataikhoan,
                    NguoiNhan = nguoinhan,
                    TongTien = tongtien,
                    SDT= sdt,
                    NgayTao= DateTime.Now,
                        
                   };
                 db.Insert(hoadon);

                

            }
        }
    }
}