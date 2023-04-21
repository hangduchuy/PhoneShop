using Microsoft.AspNet.Identity;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBPHONE.Models.BUSS;

namespace WEBPHONE.Controllers
{
    [Authorize]
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
           
            
            return View("Index");
        }
        [HttpPost]
        public ActionResult Them(string nguoinhan,string sdt,int tongtien)
        {
            try
            {
                ThanhToanBUSS.Them(nguoinhan, User.Identity.GetUserId(),sdt, tongtien);
                return RedirectToAction("../Shop/Index");
            }
            catch (Exception)
            {
                return RedirectToAction("../Shop/Index");
            }
        }

    }
}