using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using WEBPHONE.Models.BUSS;

namespace WEBPHONE.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {

            return View(ShopOnlineBUSS.DanhSachSP());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public JsonResult LoadImages(string id)
        {
            var product = ShopOnlineBUSS.ChiTiet(id);
            var images = product.HinhChinh;
            XElement xImages = XElement.Parse(images);
            List<string> listImageReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImageReturn.Add(element.Value);
            }
            return Json(new
            {
                data = listImageReturn
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveImages(string id, string images)
        {
            JavaScriptSerializer serizlizer = new JavaScriptSerializer();
            var listImages = serizlizer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(22);
                xElement.Add(new XElement("Images", subStringItem));
            }
            if (listImages.Count() == 0)
            {

                xElement.Add(new XElement("Images", "/assets/assets/products/1.png"));
            }
            try
            {
                ShopOnlineBUSS.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {

            ViewBag.MaLoaiSP = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSP", "TenLoaiSP");
            
            ViewBag.MaNSX = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNSX", "TenNSX");

            //ViewBag.MaLoaiSP =
            //ViewData["MaLoaiSP"] = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSP", "TenLoaiSP");
            //ViewData["MaNSX"] = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNSX", "TenNSX");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {

            Console.WriteLine(HttpContext);
            try
            {
                var hpf = HttpContext.Request.Files[0];
                Console.WriteLine(hpf);
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/assets/assets/products/" + fileName.Substring(2) + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSP.Substring(2) + ".png";

                }
                sp.TinhTrang = 0;
                sp.SoLuongDaBan = 0;
                sp.LuotXem = 0;
                ShopOnlineBUSS.ThemSP(sp);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            //    sp.TinhTrang = 0;
            //    sp.SoLuongDaBan = 0;
            //TODO: Add insert logic here
            //    sp.TinhTrang = 0;
            //    sp.SoLuongDaBan = 0;
            //    sp.LuotXem = 0;
            //    sp.TinhTrang = 1;
            //    XElement xElement = new XElement("Images");
            //    xElement.Add(new XElement("Images", "~/assets/assets/products/1.png"));
            //    sp.HinhChinh = xElement.ToString();



        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNSX = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNSX", "TenNSX", ShopOnlineBUSS.ChiTiet(id).MaNSX);
            ViewBag.MaLoaiSP = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSP", "TenLoaiSP", ShopOnlineBUSS.ChiTiet(id).MaLoaiSP);
            return View(ShopOnlineBUSS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, SanPham sp)
        {
            var temp = ShopOnlineBUSS.ChiTiet(id);
            try
            {
                var hpf = HttpContext.Request.Files[0];              
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSP;
                    string fullPathWithFileName = "~/assets/assets/products/" + fileName.Substring(2) + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSP.Substring(2) + ".png";
                }
                else { sp.HinhChinh = temp.HinhChinh; }
                //TODO: Add update logic here
                if (sp.SoLuongDaBan > 10000)
                {
                    sp.SoLuongDaBan = 0;
                }
                else { sp.SoLuongDaBan = temp.SoLuongDaBan; }
                if (sp.LuotXem > 10000) { sp.LuotXem = 0; } else { sp.LuotXem = temp.LuotXem; }
                sp.TinhTrang = temp.TinhTrang;

                ShopOnlineBUSS.UpdateImages(id, sp.HinhChinh);
                ShopOnlineBUSS.UpdateSP(id, sp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {
            return View(ShopOnlineBUSS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(String id, SanPham sp)
        {
            // TODO: Add delete logic here
            var tam = ShopOnlineBUSS.ChiTiet(id);
            try
            {
                // TODO: Add delete logic here
                if (tam.SoLuongDaBan > 10000)
                {
                    //reset = 0 
                    tam.SoLuongDaBan = 0;
                }
                if (tam.LuotXem > 10000)
                {
                    //reset = 0 
                    tam.LuotXem = 0;
                }
                if (tam.TinhTrang == 1)
                {
                    //reset = 0 
                    tam.TinhTrang = 0;
                }
                else
                {
                    //reset = 1
                    tam.TinhTrang = 1;
                }

                //Xoa luon
                //ShopOnlineBUSS.DeleteSP(id,sp);
                //Load lai trang index quan ly
                ShopOnlineBUSS.UpdateSP(id, tam);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }         
        }
    }
}
    
