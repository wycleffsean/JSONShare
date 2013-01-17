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
        [OutputCache(Duration=1800)]
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
                    //timestamp
                    item.Created = DateTime.UtcNow;
                    item.Updated = DateTime.UtcNow;

                    db.JsonItems.Add(item);
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = item.Id });
                }
            }
            return View(item);
        }

        //
        // GET: /Home/Edit/5
        [OutputCache(Duration=60, VaryByParam="id;jsonp;callback")]
        public ActionResult Edit(int id, string jsonp, string callback)
        {
            using (var db = new Database())
            {
                try
                {
                    var model = db.JsonItems.Find(id);
                    if (model == null)
                        throw new Exception();

                    //timestamp
                    model.Viewed = DateTime.UtcNow;
                    db.SaveChanges();

                    if (!(String.IsNullOrEmpty(jsonp) && String.IsNullOrEmpty(callback)))
                    {
                        var _jsonp = jsonp ?? callback;
                        return Content(String.Format("{0}({1})",_jsonp, model.Json));
                    }

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
                    model.Updated = DateTime.UtcNow; //timestamp
                    db.SaveChanges();
                    
                    var url = Url.Action("Edit", new { id = model.Id });                    
                    HttpResponse.RemoveOutputCacheItem(url, url);                   

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
