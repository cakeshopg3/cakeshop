using DeviceManagement.Models;
using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManagement.Controllers
{
    public class CartController : Controller
    {

        private DatabaseContext db = new DatabaseContext();

        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.categories = db.categories.ToList();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Session["cart"] = cart;
            }
            return View();
        }

        public ActionResult Buy(long? id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { product = db.products.Find(id), Quantity = quantity });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity += quantity;
                }
                else
                {
                    cart.Add(new Item { product = db.products.Find(id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            ViewBag.categories = db.categories.ToList();
            return RedirectToAction("Carts", "Homepage");
        }

        public ActionResult Remove(long? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            ViewBag.categories = db.categories.ToList();
            return RedirectToAction("Carts", "Homepage");
        }

        private int isExist(long? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.id.Equals(id))
                    return i;
            return -1;
        }

        // GET: Product/Create
        public ActionResult ThankYou()
        {
            ViewBag.categories = db.categories.ToList();
            return View();

        }

        // GET: Product/Create
        public ActionResult Checkout()
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Session["cart"] = cart;
            }
            ViewBag.countries = db.countries.ToList();
            ViewBag.cities = db.cities.ToList();
            ViewBag.districts = db.districts.ToList();
            ViewBag.wards = db.wards.ToList();

            return View();

        }

        // POST: Cart/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order([Bind(Include = "id,customer_name,phone_number,address_shipping,note,country_id, city_id, district_id, ward_id")] order order)
        {
            ViewBag.countries = db.countries.ToList();
            ViewBag.cities = db.cities.ToList();
            ViewBag.districts = db.districts.ToList();
            ViewBag.wards = db.wards.ToList();

            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                orders_item orderItem = new orders_item();
                foreach (Item item in (List<Item>)Session["cart"])
                {
                    orderItem.order_id = order.id;
                    orderItem.book_id = item.product.id;
                    orderItem.price = (decimal)item.product.origin_price;
                    orderItem.quantity = item.Quantity;
                    db.orders_item.Add(orderItem);
                    db.SaveChanges();
                }


                Session["cart"] = new List<Item>();
                return RedirectToAction("ThankYou");
            }
            ViewBag.categories = db.categories.ToList();
            return View("~/Views/Cart/Checkout.cshtml", order);
        }

    }
}
