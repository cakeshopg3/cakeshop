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
    public class ProductController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Product
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.CurrentSort = "asc";
                var sqlStr = "";
                sqlStr += "SELECT products.*, category_name, size_name, color_name ";
                sqlStr += "FROM products ";
                sqlStr += "LEFT JOIN category ON products.category = category.id ";
                sqlStr += "LEFT JOIN colors ON products.color_id = colors.id ";
                sqlStr += "LEFT JOIN sizes ON products.size_id = sizes.id ";

                var products = db.Database.SqlQuery<ProductResponseDTO>(sqlStr).OrderByDescending(o => o.product_name);
                int pageNumber = (page ?? 1);
                return View(products.ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");
        }

        // GET: Product/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                product product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: Product/Create
        public ActionResult Create()
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.categorylist = db.categories.ToList();
                ViewBag.sizes = db.sizes.ToList();
                ViewBag.colors = db.colors.ToList();
                return View();
            }
            return RedirectToAction("Login", "User");

        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,product_name,category,price,image_url,description, origin_price, isPopular, size_id, color_id")] product product)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.categorylist = db.categories.ToList();
                ViewBag.sizes = db.sizes.ToList();
                ViewBag.colors = db.colors.ToList();
                if (ModelState.IsValid)
                {
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                product product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                ViewBag.categorylist = db.categories.ToList();
                ViewBag.sizes = db.sizes.ToList();
                ViewBag.colors = db.colors.ToList();
                return View(product);
            }
            return RedirectToAction("Login", "User");

        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product_name,category,price,image_url,description, origin_price, isPopular, size_id, color_id")] product product)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.categorylist = db.categories.ToList();
                ViewBag.sizes = db.sizes.ToList();
                ViewBag.colors = db.colors.ToList();
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            return RedirectToAction("Login", "User");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                product product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            return RedirectToAction("Login", "User");

        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                product product = db.products.Find(id);
                db.products.Remove(product);
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
