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
using ShopManagement.DTO.Response;

namespace ShopManagement.Controllers
{
    public class CityController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: City
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.CurrentSort = "asc";
                var sqlStr = "";
                sqlStr += "SELECT city.id, country.country_name, city_name ";
                sqlStr += "FROM city ";
                sqlStr += "LEFT JOIN country ON city.country_id = country.id ";

                var cities = db.Database.SqlQuery<CityResponseDTO>(sqlStr).OrderByDescending(o => o.city_name);
                int pageNumber = (page ?? 1);
                return View(cities.ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");
            //return View(db.cities.ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                city city = db.cities.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            return RedirectToAction("Login", "User");
          
        }

        // GET: City/Create
        public ActionResult Create()
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                return View();
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,country_id,city_name")] city city)
        {
            ViewBag.countries = db.countries.ToList();
            if (ValidateUser.IsUserLogin())
            {
                if (ModelState.IsValid)
                {
                    db.cities.Add(city);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(city);
            }
            return RedirectToAction("Login", "User");
        }

        // GET: City/Edit/5
        public ActionResult Edit(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                city city = db.cities.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,country_id,city_name")] city city)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                if (ModelState.IsValid)
                {
                    db.Entry(city).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(city);
            }
            return RedirectToAction("Login", "User");
            
        }

        // GET: City/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                city city = db.cities.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                city city = db.cities.Find(id);
                db.cities.Remove(city);
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
