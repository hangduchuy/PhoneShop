using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BaoCao
{
    public class mapBaoCaoThongKe
    {
        //san pham
        public List<BaoCaoBanHang_TheoSanPham> BaoCaoBanHang_TheoSP(int? nam, int? thang)
        {
            try
            {
                return BaoCaoBanHang_TheoSP(nam, thang).ToList();
            }
            catch
            {
                return new List<BaoCaoBanHang_TheoSanPham>();
            }
        }
    }
}