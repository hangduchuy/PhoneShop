using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WEBPHONE.Models.BUSS
{
    public class ShopOnlineBUSS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db= new ShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where TinhTrang =0");
        }
        public static SanPham ChiTiet(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham>("Select * from SanPham where MaSP =@0",a);
        }
        //------------------admin--------------------
        public static IEnumerable<SanPham> DanhSachSP()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham");
        }
        public static void ThemSP(SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Insert(sp);
        }
        public static void UpdateSP(String id, SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Update(sp,id);
        }
        //---------------------Update Images------------------
        public static void UpdateImages(string id, string images)
        {
            var db = new ShopConnectionDB();
            var sp = ShopOnlineBUSS.ChiTiet(id);
            sp.HinhChinh = images;
            db.Update(sp, id);
        }
        //----------------ảnh đại diện sản phẩm------------
        public static string LoadAvartaImg(string id)
        {
            var sp = ChiTiet(id);

            var product = ShopOnlineBUSS.ChiTiet(id);
            
            
            var images = product.HinhChinh;
            return "/assets/assets/products/"+images;
            //XElement xImages = XElement.Parse(images);

            //List<string> listImageReturn = new List<string>();

            //foreach (XElement element in xImages.Elements())
            //{
            //    listImageReturn.Add(element.Value);
            //}
            //if (listImageReturn.Count() == 0)
            //{
            //    return "/assets/assets/products/1.png";
            //}
            //return listImageReturn.ElementAt(0).ToString();
        }

        public static void DeleteSP(String id, SanPham sp)
        {
            var db = new ShopConnectionDB();
            

            //Xóa luôn
            db.Delete<SanPham>("Where MaSP = @0", id);
            db.Save(sp);
        }
    }
}