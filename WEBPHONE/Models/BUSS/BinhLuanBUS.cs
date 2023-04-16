using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopConnection;
namespace WEBPHONE.Models.BUSS
{
    public class BinhLuanBUS
    {
        public static List<BinhLuan> LoadBinhLuan()
        {
            var db = new ShopConnectionDB();
            return db.Query<BinhLuan>("select * from BinhLuan ORDER BY NgayBL desc").ToList();
        }
        public static void Them(string masanpham, string mataikhoan, string noidung)
        {

            using (var db = new ShopConnectionDB())
            {
                BinhLuan binhluan = new BinhLuan()
                {
                    CustomerID=mataikhoan,
                    ProductID=masanpham,
                    Content=noidung,
                    NgayBL = DateTime.Now,

                };
                db.Insert(binhluan);



            }
        }
        public static List<BinhLuan> LoadBinhLuanBySanPhamId(string sanPhamId)
        {
            var db = new ShopConnectionDB();
            return db.Query<BinhLuan>("SELECT * FROM BinhLuan WHERE ProductID = @Id ORDER BY NgayBL DESC", new { Id = sanPhamId }).ToList();
        }

    }
}