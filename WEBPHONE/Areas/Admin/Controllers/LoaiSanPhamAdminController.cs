using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBPHONE.Models.BUSS;

namespace WEBPHONE.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/LoaiSanPhamAdmin
        public ActionResult Index()
        {
            var db = LoaiSanPhamBUS.DanhSachAdmin();
            return View(db);
        }

        // GET: Admin/LoaiSanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPhamBUS.ThemLSP(lsp);
                LoaiSanPhamBUS.UpdateLSP(id,lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            var db = LoaiSanPhamBUS.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                LoaiSanPhamBUS.EditLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/LoaiSanPhamAdmin/TempDelete/5
        public ActionResult TempDelete(String id)
        {
            var db = LoaiSanPhamBUS.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPhamAdmin/TempDelete/5
        [HttpPost]
        public ActionResult TempDelete(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add delete logic here
                lsp.TinhTrang = "1";

                // Xóa tạm 
                LoaiSanPhamBUS.EditLSP(id,lsp);
                //

                //Xóa luôn 
                //LoaiSanPhamBUS.DeleteLSP(id, lsp);
                //

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/LoaiSanPhamAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Delete/5
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
    }
}
