using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBPHONE.Models.BUSS;

namespace WEBPHONE.Controllers
{
    public class BinhLuanController : Controller
    {
        [Authorize]
        // GET: BinhLuan
        public ActionResult Index()
        {
            
            
            return View(BinhLuanBUS.LoadBinhLuan());
        }
        [HttpPost]
        public ActionResult Create(string masanpham,string noidung)
        {

            try
            {
                BinhLuanBUS.Them(masanpham, User.Identity.GetUserId(), noidung);
                return RedirectToAction("../Shop/Index");
            }
            catch (Exception)
            {
                return RedirectToAction("../Shop/Index");
            }
        }
    }
}