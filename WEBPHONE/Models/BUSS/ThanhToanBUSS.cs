using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WEBPHONE.Models.BUSS
{
    public class ThanhToanBUSS
    {
        public class CartItem
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public int ProductPrice { get; set; }
            public int ProductQuantity { get; set; }
        }
        public static void Them(string nguoinhan, string mataikhoan, string sdt, int tongtien)
        {
            using (var db = new ShopConnectionDB())
            {
                HoaDon hoadon = new HoaDon()
                {
                    NguoiDat = mataikhoan,
                    NguoiNhan = nguoinhan,
                    TongTien = tongtien,
                    TrangThai = 1,
                    SDT = sdt,
                    NgayTao = DateTime.Now,
                };

                db.Insert(hoadon);

                

            }
        }

    }
}
