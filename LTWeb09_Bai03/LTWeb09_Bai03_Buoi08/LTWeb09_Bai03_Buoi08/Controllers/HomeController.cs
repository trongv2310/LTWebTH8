using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb09_Bai03_Buoi08.Models;
using System.IO;
using System.Net;

namespace LTWeb09_Bai03_Buoi08.Controllers
{
    public class HomeController : Controller
    {
        Model1 data = new Model1();
        public ActionResult Index()
        {
            List<Employee> employees = data.Employees.ToList();
            return View(employees);
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
            ViewBag.DeptId = new SelectList(data.Departments.ToList(), "DeptId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName);

                    string uploadDir = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    string savePath = Path.Combine(uploadDir, fileName);

                    ImageFile.SaveAs(savePath);

                    emp.Img = "~/Content/Images/" + fileName;
                }
                else
                {
                    emp.Img = "~/Content/Images/nham.png";
                }

                if (ModelState.IsValid)
                {
                    data.InsertOnSubmit(emp);
                    data.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.Message);
            }

            ViewBag.DeptId = new SelectList(data.Departments.ToList(), "DeptId", "Name", emp.DeptId);
            return View("ThemMoi", emp);
        }
        public ActionResult Edit(int? id)
        {
            var emp = data.Employees.First(m => m.Id == id);
            ViewBag.DeptId = new SelectList(data.Departments.ToList(), "DeptId", "Name", emp.DeptId);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (ImageFile != null && ImageFile.ContentLength > 0)
                    {

                        string fileName = Path.GetFileName(ImageFile.FileName);
                        string uploadDir = Server.MapPath("~/Content/Images");
                        if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                        string savePath = Path.Combine(uploadDir, fileName);
                        ImageFile.SaveAs(savePath);
                        emp.Img = "~/Content/Images/" + fileName;
                    }
                    else
                    {

                        var oldImgPath = data.Employees.AsNoTracking().Where(e => e.Id == emp.Id).Select(e => e.Img).FirstOrDefault();
                        emp.Img = oldImgPath;
                    }

                    data.UpdateOnSubmit(emp);
                    data.SubmitChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi cập nhật: " + ex.Message);
            }

            ViewBag.DeptId = new SelectList(data.Departments.ToList(), "DeptId", "Name", emp.DeptId);
            return View(emp);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = data.Employees
                                    .Include("Department") 
                                    .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = data.Employees
                                    .Include("Department") 
                                    .FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = data.Employees.Find(id);

            data.DeleteOnSubmit(employee); 
            data.SubmitChanges();

            return RedirectToAction("Index");
        }
        public ActionResult BrowseByDepartment(int? deptId)
        {
            ViewBag.Departments = data.Departments.ToList();

            var employeesQuery = data.Employees.Include("Department").AsQueryable();

            if (deptId != null)
            {
                employeesQuery = employeesQuery.Where(e => e.DeptId == deptId.Value);
                ViewBag.SelectedDeptName = data.Departments
                                      .Where(d => d.DeptId == deptId.Value)
                                      .Select(d => d.Name)
                                      .FirstOrDefault();
            }
            else
            {
                ViewBag.SelectedDeptName = "Tất cả nhân viên";
            }
            List<Employee> employees = employeesQuery.ToList();
            return View(employees);
        }
    }
}
