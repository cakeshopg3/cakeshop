using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopManagement.DTO.Response;
using ShopManagement.Models;
using PagedList;

namespace ShopManagement.Controllers
{
    public class DistrictController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: District
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.CurrentSort = "asc";
                var sqlStr = "";
                sqlStr += "SELECT district.id, country.country_name, city.city_name, district_name ";
                sqlStr += "FROM district ";
                sqlStr += "LEFT JOIN country ON district.country_id = country.id ";
                sqlStr += "LEFT JOIN city ON district.city_id = city.id ";

                var cities = db.Database.SqlQuery<DistrictResponseDTO>(sqlStr).OrderByDescending(o => o.country_name);
                int pageNumber = (page ?? 1);
                return View(cities.ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");
        }

        // GET: District/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                district district = db.districts.Find(id);
                if (district == null)
                {
                    return HttpNotFound();
                }
                return View(district);
            }
            return RedirectToAction("Login", "User");
        }

        // GET: District/Create
        public ActionResult Create()
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                return View();
            }
            return RedirectToAction("Login", "User");
           
        }

        // POST: District/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,country_id,city_id,district_name")] district district)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                if (ModelState.IsValid)
                {
                    db.districts.Add(district);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(district);
            }
            return RedirectToAction("Login", "User");
           
        }

        // GET: District/Edit/5
        public ActionResult Edit(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                district district = db.districts.Find(id);
                if (district == null)
                {
                    return HttpNotFound();
                }
                return View(district);
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: District/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,country_id,city_id,district_name")] district district)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                if (ModelState.IsValid)
                {
                    db.Entry(district).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(district);
            }
            return RedirectToAction("Login", "User");
           
        }

        // GET: District/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                district district = db.districts.Find(id);
                if (district == null)
                {
                    return HttpNotFound();
                }
                return View(district);
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                district district = db.districts.Find(id);
                db.districts.Remove(district);
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
