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
    public class CountryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Country
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                int pageNumber = (page ?? 1);
                return View(db.countries.OrderBy(u => u.id).ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");
        }

        // GET: Country/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                country country = db.countries.Find(id);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
            }
            return RedirectToAction("Login", "User");
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            if (ValidateUser.IsUserLogin())
            {
                return View();
            }
            return RedirectToAction("Login", "User");

        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,country_name")] country country)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (ModelState.IsValid)
                {
                    db.countries.Add(country);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(country);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: Country/Edit/5
        public ActionResult Edit(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                country country = db.countries.Find(id);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
            }
            return RedirectToAction("Login", "User");

        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,country_name")] country country)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(country);
            }
            return RedirectToAction("Login", "User");
            
        }

        // GET: Country/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                country country = db.countries.Find(id);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
            }
            return RedirectToAction("Login", "User");
          
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                country country = db.countries.Find(id);
                db.countries.Remove(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "User");
            
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
