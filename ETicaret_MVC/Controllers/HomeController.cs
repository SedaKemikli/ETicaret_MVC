using ETicaret_MVC.Contexts;
using ETicaret_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret_MVC.Controllers
{
    public class HomeController : Controller
    {
        ProductContext context = new ProductContext();

        public ActionResult Index()
        {
            return View(context.Products.Where(i => i.IsHome && i.IsActive).Select(i => new ProductModel()
            {
                Id= i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0,47) + "...":i.Description,
                Price= i.Price,
                StockAmount = i.StockAmount,
                Image = i.Image ?? "2.jpg",

            }).ToList());
        }

        public ActionResult List(int? id)
        {
            var ürünler= context.Products.Where(i => i.IsActive).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                StockAmount = i.StockAmount,
                Image = i.Image ?? "2.jpg",
                CategoryId = i.CategoryId

            }).AsQueryable();

            if (id != null)
            {
                ürünler = ürünler.Where(i => i.CategoryId == id);
            }

            return View(ürünler.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(context.Categories.ToList());
        }


    }
}