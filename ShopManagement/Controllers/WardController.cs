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
    public class WardController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Ward
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.CurrentSort = "asc";
                var sqlStr = "";
                sqlStr += "SELECT ward.id, country.country_name, city.city_name, district.district_name,ward_name ";
                sqlStr += "FROM ward ";
                sqlStr += "LEFT JOIN country ON ward.country_id = country.id ";
                sqlStr += "LEFT JOIN city ON ward.city_id = city.id ";
                sqlStr += "LEFT JOIN district ON ward.district_id = district.id ";

                var cities = db.Database.SqlQuery<WardResponseDTO>(sqlStr).OrderByDescending(o => o.country_name);
                int pageNumber = (page ?? 1);
                return View(cities.ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");
        }

        // GET: Ward/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ward ward = db.wards.Find(id);
                if (ward == null)
                {
                    return HttpNotFound();
                }
                return View(ward);
            }
            return RedirectToAction("Login", "User");
            
        }

        // GET: Ward/Create
        public ActionResult Create()
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                ViewBag.districts = db.districts.ToList();
                return View();
            }
            return RedirectToAction("Login", "User");
           
        }

        // POST: Ward/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,country_id,city_id,district_id,ward_name")] ward ward)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                ViewBag.districts = db.districts.ToList();
                if (ModelState.IsValid)
                {
                    db.wards.Add(ward);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(ward);
            }
            return RedirectToAction("Login", "User");

          
        }

        // GET: Ward/Edit/5
        public ActionResult Edit(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                ViewBag.districts = db.districts.ToList();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ward ward = db.wards.Find(id);
                if (ward == null)
                {
                    return HttpNotFound();
                }
                return View(ward);
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: Ward/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,country_id,city_id,district_id,ward_name")] ward ward)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.countries = db.countries.ToList();
                ViewBag.cities = db.cities.ToList();
                ViewBag.districts = db.districts.ToList();
                if (ModelState.IsValid)
                {
                    db.Entry(ward).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(ward);
            }
            return RedirectToAction("Login", "User");
           
        }

        // GET: Ward/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ward ward = db.wards.Find(id);
                if (ward == null)
                {
                    return HttpNotFound();
                }
                return View(ward);
            }
            return RedirectToAction("Login", "User");
            
        }

        // POST: Ward/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                ward ward = db.wards.Find(id);
                db.wards.Remove(ward);
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
