using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBPHONE.Models.BUSS;
using Microsoft.AspNet.Identity;

namespace WEBPHONE.Controllers
{
    [Authorize]
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            ViewBag.TongTien= GioHangBUS.TongTien(User.Identity.GetUserId());
            return View(GioHangBUS.DanhSach(User.Identity.GetUserId()));
        }
        [HttpPost]
        public ActionResult Them(string masanpham,int soluong,int gia,string tensanpham) {
            try
            {
                GioHangBUS.Them(masanpham,User.Identity.GetUserId(), soluong, gia,tensanpham);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("../Shop/Index");
            }
        }
        [HttpPost]
        public ActionResult CapNhat(string masanpham, int soluong, int gia, string tensanpham)
        {
            try
            {
                GioHangBUS.CapNhat(masanpham, User.Identity.GetUserId(), soluong, gia, tensanpham);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Shop/Index");
            }

        }
        [HttpGet]
        public ActionResult Xoa(string masanpham)
        {
            try
            {
                GioHangBUS.Xoa(masanpham, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("../Shop/Index");
            }

        }

    }
}