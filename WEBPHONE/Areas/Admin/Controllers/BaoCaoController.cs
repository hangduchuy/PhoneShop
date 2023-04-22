using Newtonsoft.Json;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WEBPHONE.Areas.Admin.Controllers
{
    public class BaoCaoController : Controller
    {
        // GET: Admin/BaoCao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            var db = new ShopConnectionDB();
            var data = db.Fetch<dynamic>("SELECT MONTH(NgayTao) AS Thang, SUM(TongTien) AS TongThang FROM HoaDon GROUP BY MONTH(NgayTao) ORDER BY MONTH(NgayTao) ASC");
            var data2 = db.Fetch<dynamic>("SELECT YEAR(NgayTao) AS Nam, SUM(TongTien) AS TongNam FROM HoaDon GROUP BY YEAR(NgayTao) ORDER BY YEAR(NgayTao) ASC");

            //Tháng
            var chartData = new
            {               
                labels = data.Select(x => x.Thang).ToArray(),
               
                datasets = new[]
                {
                    new
                    {
                        label = "Tổng tiền của tháng",
                        data = data.Select(x => x.TongThang).ToArray(),
                        backgroundColor = "#3e95cd",
                
                    }
                }
            };

            //Năm
            var chartData2 = new
            {
                labels = data2.Select(x => x.Nam).ToArray(),

                datasets = new[]
                {
                    new
                    {
                        label = "Tổng tiền của Năm",
                        data = data2.Select(x => x.TongNam).ToArray(),
                        //backgroundColor = "#3e95cd",
                        backgroundColor = ["#4e73df", "#1cc88a", "#36b9cc"]

                    }
                }
            };

            ViewBag.ChartData = JsonConvert.SerializeObject(chartData);
            ViewBag.ChartData2 = JsonConvert.SerializeObject(chartData2);

            return View();
        }

    }
}