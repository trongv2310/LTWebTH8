using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTWeb08_Bai02.Models;
using System.IO;

namespace LTWeb08_Bai02.Controllers
{
    public class SACHController : Controller
    {
        private QLSACH db = new QLSACH();

        public ActionResult Index()
        {
            var sACH = db.SACH.Include(s => s.CHUDE).Include(s => s.NHAXUATBAN);
            return View(sACH.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,GiaBan,MoTa,AnhBia,NgayCapNhat,SoLuongTon,MaCD,MaNXB")] SACH sACH, HttpPostedFileBase ImageFile)
        {
            try
            {
                // Xử lý file ảnh được upload
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    // 1. Lấy tên file
                    string fileName = Path.GetFileName(ImageFile.FileName);

                    // 2. Tạo đường dẫn lưu file (Dựa theo CSDL của bạn)
                    // (Bạn phải tự tạo thư mục "Images" trong thư mục "Content")
                    string savePath = Path.Combine(Server.MapPath("~/Content/Images"), fileName);

                    // 3. Lưu file
                    ImageFile.SaveAs(savePath);

                    // 4. Gán đường dẫn file vào CSDL
                    sACH.AnhBia = "~/Content/Images/" + fileName;
                }
                else
                {
                    // (Tùy chọn) Gán ảnh mặc định nếu không upload
                    sACH.AnhBia = "~/Content/Images/default.png";
                }
                if (ModelState.IsValid)
                {
                    db.SACH.Add(sACH);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.Message);
            }

            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenChuDe", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenChuDe", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,GiaBan,MoTa,AnhBia,NgayCapNhat,SoLuongTon,MaCD,MaNXB")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenChuDe", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH sACH = db.SACH.Find(id);
            db.SACH.Remove(sACH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
