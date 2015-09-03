using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private EmploeesDBEntities1 db = new EmploeesDBEntities1();
        private int size = 15;
        public ViewResult Index(string filter, int pageNum = 0)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(filter) ? String.Empty: filter;
            ViewData["PageNum"] = pageNum;            
            ViewData["PageSize"] = size;

            var emploees = (from emploee in db.Emploees
                            orderby emploee.Id
                            select emploee).Skip(size * pageNum).Take(size);
            switch (filter)
            {
                case "Active": 
                emploees = (from emploee in db.Emploees
                            where emploee.Status==true
                            orderby emploee.Id
                            select emploee).Skip(size * pageNum).Take(size);
                break;
                
                case "Non-active":
                emploees = (from emploee in db.Emploees
                            where emploee.Status == false
                            orderby emploee.Id
                            select emploee).Skip(size * pageNum).Take(size);
                break;
            }
            ViewData["CountOfItems"] = emploees.Count();
            return View(emploees.ToList());
        }
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult Create()
        {
            Emploee emploee = new Emploee();
            return View(emploee);
        }
        
        [HttpPost]
        public ActionResult Create(Emploee emploee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Emploees.Add(emploee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex);
            } 
            return View(emploee);
        }
        public ActionResult Edit(int id)
        {
            EmploeesDBEntities1 db = new EmploeesDBEntities1();
            var emploeeEdit = (from emploee in db.Emploees
                               where emploee.Id == id
                               select emploee).First();
            return View(emploeeEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var emploeeEdit = (from emploee in db.Emploees
                               where emploee.Id == id
                               select emploee).First();
            try
            {
                UpdateModel(emploeeEdit);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch 
            {
                return View(emploeeEdit);
            }
        }

        public ActionResult Delete(int id)
        {
            var emploeeDelete = (from emploee in db.Emploees
                               where emploee.Id == id
                               select emploee).First();
            return View(emploeeDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var emploeeDelete = (from emploee in db.Emploees
                               where emploee.Id == id
                               select emploee).First();
            try
            {
                db.Emploees.Remove(emploeeDelete);
                return RedirectToAction("Index");

            }
            catch
            {
                return View(emploeeDelete);
            }
        }
    }
}
