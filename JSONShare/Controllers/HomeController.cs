using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSONShare.Models;

namespace JSONShare.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            var model = new JsonItem();
            return View(model);
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")]JsonItem item)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Database())
                {
                    item.Json = item.Json.Trim();
                    db.JsonItems.Add(item);
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = item.Id });
                }
            }
            return View(item);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            using (var db = new Database())
            {
                try
                {
                    var model = db.JsonItems.Find(id);
                    return View(model);
                }
                catch (Exception)
                {
                    return RedirectToAction("Create");
                }
            }
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, [Bind(Exclude = "Id")]JsonItem item)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Database())
                {
                    var model = db.JsonItems.Find(id);
                    model.Json = item.Json;
                    model.Title = item.Title;
                    db.SaveChanges();

                    return View(model);
                }
            }
            return View(item);
        }

        ////
        //// GET: /Home/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Home/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
