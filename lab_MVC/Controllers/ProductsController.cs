using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_MVC.Controllers
{
    public class Product
    {
        public string Kod{ get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    };



    public class ProductsController : Controller
    {
        // GET: Products
        public List<Product> Products = new List<Product>()
        {
            new Product() {Category = "Biathletes", Kod = "AB-100", Title = "C. Чепиков",Date = new DateTime(2015,01,01)},
            new Product() {Category = "Biathletes", Kod = "AB-200", Title = "С. Рожков", Date = new DateTime(2015,01,02)},
            new Product() {Category = "Biathletes", Kod = "AB-300", Title = "Н. Круглов",Date = new DateTime(2015,01,03)},
            new Product() {Category = "Biathletes", Kod = "AB-400", Title = "П. Ростовцев",Date = new DateTime(2015,01,04)}
        };

        public ActionResult Index(string kod)
        {
            ViewBag.Products = Products;

            return View();
        }

        public ActionResult Product(string kod)
        {
            var product = Products.First(prod => prod.Kod == kod);
            ViewBag.Product = product;

            return View();
        }

        public ActionResult Print(string kod)
        {
            var product = Products.First(prod => prod.Kod == kod);
            ViewBag.Product = product;
            return View();
        }


        public ActionResult Athletes(string athletes, int page)
        {
            var products = Products.Where(prod => prod.Category == athletes);
            ViewBag.Products = products;
            ViewBag.Page = page;
            return View();
        }

        public ActionResult Date(string date, int page)
        {
            var date1 = DateTime.Parse(date);
            var products = Products.Where(prod => prod.Date == date1);
            ViewBag.Products = products;
            ViewBag.Page = page;
            return View();
        }
    }
}