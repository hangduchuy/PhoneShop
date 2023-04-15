using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BUSS
{
    public class GioHangBUS
    {
        public static void Them(string masanpham, string mataikhoan, int soluong, int gia, string tensanpham)
        {

            using (var db = new ShopConnectionDB())
            {
                var x = db.Query<GioHang>("SELECT * FROM GioHang WHERE MaTaiKhoan = @0 AND MaSP = @1", mataikhoan, masanpham).ToList();
                if (x.Count() > 0)
                {
                    // gọi hàm update so lượng
                    int a = (int)x.ElementAt(0).SoLuong + soluong;
                    CapNhat(masanpham, mataikhoan, a, gia, tensanpham);
                }
                else
                {
                    GioHang giohang = new GioHang()
                    {
                        MaSP = masanpham,
                        MaTaiKhoan = mataikhoan,
                        SoLuong = soluong,
                        Gia = gia,
                        TenSP = tensanpham,
                        TongTien = gia * soluong
                    };
                    db.Insert(giohang);

                }

            }
        }

        public static IEnumerable<GioHang> DanhSach(string mataikhoan)
        {
            using (var db = new ShopConnectionDB())
            {
                return db.Query<GioHang>("select * from GioHang where MaTaiKhoan = '" + mataikhoan + "'");
            }
        }
        public static void CapNhat(string masanpham, string mataikhoan, int soluong, int gia, string tensanpham)
        {
            using (var db = new ShopConnectionDB())
            {
                GioHang giohang = new GioHang()
                {
                    MaSP = masanpham,
                    MaTaiKhoan = mataikhoan,
                    SoLuong = soluong,
                    Gia = gia,
                    TenSP = tensanpham,
                    TongTien = gia * soluong
                };
                var tamp = db.Query<GioHang>("Select idGH from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSP = '" + masanpham + "'").FirstOrDefault();

                db.Update(giohang, tamp.IdGH);

            }
        }
        public static void Xoa(string masanpham, string mataikhoan)
        {
            using (var db = new ShopConnectionDB())
            {
                var a = db.Query<GioHang>("select * from GioHang where MaSP = '" + masanpham + "' and MaTaiKhoan ='" + mataikhoan + "'").FirstOrDefault();
                db.Delete(a);
            }
        }
        public static int TongTien(string mataikhoan)
        {
            using (var db = new ShopConnectionDB())
            {
                List<GioHang> a = DanhSach(mataikhoan).ToList();
                if (a.Count() == 0)
                {
                    return 0;
                }
                return db.Query<int>("select sum(Gia) from GioHang where MaTaiKhoan = '" + mataikhoan + "' ").FirstOrDefault();

            }
        }
    }
   
}