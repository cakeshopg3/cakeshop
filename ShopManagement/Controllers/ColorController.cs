using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopManagement.Models;
using PagedList;

namespace ShopManagement.Controllers
{
    public class ColorController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Color
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                int pageNumber = (page ?? 1);
                return View(db.colors.OrderBy(u => u.id).ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");
        }

        // GET: Color/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            color color = db.colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,color_name")] color color)
        {
            if (ModelState.IsValid)
            {
                db.colors.Add(color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(color);
        }

        // GET: Color/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            color color = db.colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: Color/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,color_name")] color color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(color).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(color);
        }

        // GET: Color/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            color color = db.colors.Find(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            color color = db.colors.Find(id);
            db.colors.Remove(color);
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
