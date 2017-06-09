//
// author: Shawn
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTS.Controllers
{
    public class StudentController : Controller
    {
        private Manager m = new Manager();

        //GET search
        public ActionResult Search()
        {
            return View();
        }

        //POST search
        [HttpPost]
        public ActionResult Search(int? id, StudentSearch newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("search");
            }

            var foundStudents = m.StudentSearch(newItem);
            if (foundStudents == null || foundStudents.Count() == 0)
            {
                return RedirectToAction("search");
            }

            
            return View("SearchPost", foundStudents);
        }


        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
