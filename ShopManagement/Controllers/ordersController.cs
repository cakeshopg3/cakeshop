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
using System.Data.SqlClient;
using ShopManagement.DTO.Response;

namespace ShopManagement.Controllers
{
    public class ordersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: orders
        public ActionResult Index(int? page)
        {
            if (ValidateUser.IsUserLogin())
            {
                ViewBag.CurrentSort = "asc";
                var sqlStr = "";
                sqlStr += "SELECT orders.*, country_name, city_name, district_name,ward_name ";
                sqlStr += "FROM orders ";
                sqlStr += "LEFT JOIN country ON orders.country_id = country.id ";
                sqlStr += "LEFT JOIN city ON orders.city_id = city.id ";
                sqlStr += "LEFT JOIN district ON orders.district_id = district.id ";
                sqlStr += "LEFT JOIN ward ON orders.ward_id = ward.id ";

                var cities = db.Database.SqlQuery<OrderResponseDTO>(sqlStr).OrderByDescending(o => o.id);
                int pageNumber = (page ?? 1);
                return View(cities.ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
                //return View(db.orders.OrderBy(u => u.id).ToPagedList(pageNumber, Const.Const.PAGE_SIZE));
            }
            return RedirectToAction("Login", "User");

        }

        // GET: orders/Details/5
        public ActionResult Details(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var sqlStr = "";
                sqlStr += "SELECT orders_item.id, orders_item.order_id, orders_item.book_id as product_id, products.product_name, orders_item.quantity, orders_item.price, size_name, color_name ";
                sqlStr += "FROM orders_item ";
                sqlStr += "LEFT JOIN products ON orders_item.book_id = products.id ";
                sqlStr += "LEFT JOIN sizes ON products.size_id = sizes.id ";
                sqlStr += "LEFT JOIN colors ON products.color_id = colors.id ";
                sqlStr += "WHERE  orders_item.order_id = @id ";
                var orderItems = db.Database.SqlQuery<OrderItemDetail>(sqlStr, new SqlParameter("@id", id));
                //List<orders_item> items = db.orders_item.Where(item => item.order_id == id).ToList();

                return View(orderItems.ToList());
            }
            return RedirectToAction("Login", "User");

        }

      
        // GET: orders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (ValidateUser.IsUserLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                order order = db.orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            return RedirectToAction("Login", "User");

        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (ValidateUser.IsUserLogin())
            {
                order order = db.orders.Find(id);
                db.orders.Remove(order);
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
