using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models
{
    using System;
    public partial class BaoCaoBanHang_TheoSanPham
    {
        public int ID { get; set; }
        public string TenSP { get; set; }
        public Nullable<double> SoLuong { get; set; }
    }
}