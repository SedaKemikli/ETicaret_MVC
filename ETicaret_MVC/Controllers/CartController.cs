using ETicaret_MVC.Contexts;
using ETicaret_MVC.Entities;
using ETicaret_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret_MVC.Controllers
{
    public class CartController : Controller
    {
        private ProductContext db = new ProductContext(); 
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart =(Cart)Session["Cart"]; //Session kullanıcıya özel oluşturulan bir depo.

            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;

        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult CheckOut()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult CheckOut(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("SepetBosHatası", "Sepetinizde ürün bulunmamaktadır!");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
            
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = (new Random()).Next(0000, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.AdSoyad = User.Identity.GetUserName();
            //order.AdSoyad = entity.AdSoyad;
            order.AdresBaslıgı = entity.AdresBaslıgı;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Ilce = entity.Ilce;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}