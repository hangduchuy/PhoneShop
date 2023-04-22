using Newtonsoft.Json;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBPHONE.Areas.Admin.Controllers
{
    public class MainAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/MainAdmin
        public ActionResult Index(int? nam, int? thang)
        {
            ViewBag.nam = nam ?? DateTime.Now.Year;
            ViewBag.thang = thang;
            return View();
        }

        // GET: Admin/MainAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MainAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MainAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MainAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MainAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MainAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MainAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

