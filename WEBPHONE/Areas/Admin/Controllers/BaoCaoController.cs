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
            var data = db.Fetch<dynamic>("SELECT TongTien FROM HoaDon ORDER BY NgayTao DESC");

            var chartData = new
            {
                labels = "Total",
                //labels = data.Select(x => x.).ToArray(),
                datasets = new[]
                {
            new
            {
                label = "Total",
                data = data.Select(x => x.TongTien).ToArray(),
                backgroundColor = "#3e95cd"
            }
        }
            };

            ViewBag.ChartData = JsonConvert.SerializeObject(chartData);

            return View();
        }

    }
}