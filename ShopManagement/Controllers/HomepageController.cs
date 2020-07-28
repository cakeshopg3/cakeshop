using DeviceManagement.Models;
using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class HomepageController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Homepage
        public ActionResult Index(int? category_id, string searchString)
        {
            ViewBag.categories = db.categories.ToList();
            //var products = from p in db.products
            //               select p;
            //if (category_id != null && String.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(p => p.category == category_id);
            //}
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(s => s.product_name.Contains(searchString));
            //}

            //ViewBag.products = products.ToList();
            //var productsPopular = db.products.Where(p => p.isPopular == true);
            //ViewBag.productsPopular = productsPopular.ToList();
            var productSales = db.products.Take(5);
            ViewBag.productSales = productSales.ToList();
            return View();
        }

        // GET: ThietBis/Details/5
        public ActionResult Details(long? id)
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
            var products = db.products.Where(p => p.category == product.category);
            ViewBag.products = products.ToList();
            ViewBag.categories = db.categories.ToList();
            ViewBag.sizes = db.sizes.ToList();
            ViewBag.colors = db.colors.ToList();
            return View(product);
        }

        // GET: ThietBis/Details/5
        public ActionResult Shopping(int? category_id, string searchString, string orderBy, string orderByMoney)
        {
            ViewBag.categories = db.categories.ToList();
            var products = from p in db.products
                           select p;
            if (category_id != null && String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.category == category_id);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.product_name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(orderBy))
            {
                if (orderBy == "asc")
                {
                    products = products.OrderBy(p => p.product_name);
                }
                else
                {
                    products = products.OrderByDescending(p => p.product_name);
                }

            }
            ViewBag.products = products.ToList();
            ViewBag.sizes = db.sizes.ToList();
            ViewBag.colors = db.colors.ToList();
            return View();
        }

        // GET: Homepage
        public ActionResult Contact()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        // GET: Homepage
        public ActionResult About()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }
        // GET: Homepage
        public ActionResult Payment()
        {
            ViewBag.countries = db.countries.ToList();
            ViewBag.cities = db.cities.ToList();
            ViewBag.districts = db.districts.ToList();
            ViewBag.wards = db.wards.ToList();
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        public ActionResult PaymentFinal()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        // GET: Homepage
        public ActionResult Login()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        // GET: Homepage
        public ActionResult Register()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        public ActionResult News()
        {
            ViewBag.categories = db.categories.ToList();
            return View();
        }

        public ActionResult Carts()
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                Session["cart"] = cart;
            }
            ViewBag.categories = db.categories.ToList();
            var bestSeller = db.products.Take(5);
            ViewBag.bestSeller = bestSeller.ToList();
            return View();
        }

        public ActionResult ProductDetail(int? id)
        {
            ViewBag.categories = db.categories.ToList();
            ViewBag.sizes = db.sizes.ToList();
            ViewBag.colors = db.colors.ToList();
            var productDetail = db.products.Find(id);
            ViewBag.productDetail = productDetail;
            var productCate = db.products.Where(p => p.category == productDetail.category);
            ViewBag.productCate = productCate.ToList();
            var bestSeller = db.products.Take(5);
            ViewBag.bestSeller = bestSeller.ToList();
            return View();
        }

        public ActionResult Menu(int? id, string orderBy, string orderByMoney, string searchString)
        {
            var productsPopular = db.products.Where(p => p.isPopular == true);
            ViewBag.productsPopular = productsPopular.ToList();
            var productSales = db.products.Where(p => p.price != null).Take(4);
            ViewBag.productSales = productSales.ToList();
            var allProduct = from p in db.products select p;
            if (id != null)
            {
                allProduct = allProduct.Where(p => p.category == id);

            }
            if (!String.IsNullOrEmpty(orderBy))
            {
                if (orderBy == "asc")
                {
                    allProduct = allProduct.OrderBy(p => p.product_name);
                }
                else
                {
                    allProduct = allProduct.OrderByDescending(p => p.product_name);
                }

            }
            if (!String.IsNullOrEmpty(orderByMoney))
            {
                if (orderByMoney == "asc")
                {
                    allProduct = allProduct.OrderBy(p => p.price);
                }
                else
                {
                    allProduct = allProduct.OrderByDescending(p => p.price);
                }

            }
            ViewBag.allProduct = allProduct.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.allProduct = db.products.Where(a => a.product_name.Contains(searchString)).ToList();
            }
            ViewBag.categories = db.categories.ToList();
            return View();
        }
    }
}