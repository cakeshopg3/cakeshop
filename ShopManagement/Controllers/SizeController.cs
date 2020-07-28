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
    public class SizeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Size
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                int pageNumber = (page ?? 1);
                return View(db.sizes.OrderBy(u => u.id).ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");

        }

        // GET: Size/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            size size = db.sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // GET: Size/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Size/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,size_name")] size size)
        {
            if (ModelState.IsValid)
            {
                db.sizes.Add(size);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(size);
        }

        // GET: Size/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            size size = db.sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // POST: Size/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,size_name")] size size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(size);
        }

        // GET: Size/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            size size = db.sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // POST: Size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            size size = db.sizes.Find(id);
            db.sizes.Remove(size);
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
