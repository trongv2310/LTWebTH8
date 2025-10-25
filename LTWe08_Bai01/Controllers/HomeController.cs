using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWe08_Bai01.Models;

namespace LTWe08_Bai01.Controllers
{
    public class HomeController : Controller
    {
        BookStore data = new BookStore();
        public ActionResult Index()
        {
            List<Theloaitin> ds = data.Theloaitins.ToList();
            return View(ds);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Theloaitin ltin)
        {
            data.InsertOnSubmit(ltin);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var EB_tin = data.Theloaitins.First(m => m.IDLoai == id);
            return View(EB_tin);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var Ltin = data.Theloaitins.First(m => m.IDLoai == id);
            var E_Loaitin = collection["Tentheloai"];

            Ltin.IDLoai = id;

            Ltin.Tentheloai = E_Loaitin;

            //UpdateModel(Ltin);
            data.UpdateOnSubmit(Ltin);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var Details_tin = data.Theloaitins.Where(m => m.IDLoai == id).First();
            return View(Details_tin);
        }
        public ActionResult Delete(int id)
        {
            var D_tin = data.Theloaitins.First(m => m.IDLoai == id);
            data.DeleteOnSubmit(D_tin);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
       
    }
}