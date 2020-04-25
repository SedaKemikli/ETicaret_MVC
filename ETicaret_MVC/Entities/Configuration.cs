using ETicaret_MVC.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ETicaret_MVC.Entities
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductContext context)
        {
            List<Category> categoryList = new List<Category>()
            {
                new Category()
                {
                    Name = "Tişört"
                },
                new Category()
                {
                    Name = "Bluz"
                },
                new Category()
                {
                    Name = "Gömlek"
                },
                new Category()
                {
                    Name = "Pantolon"
                },
                new Category()
                {
                    Name = "Şort"
                },
                new Category()
                {
                    Name = "Elbise"
                },
                new Category()
                {
                    Name = "Tulum"
                }
            };

            foreach (var category in categoryList)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            List<Product> productList = new List<Product>()
            {
                new Product()
                {
                    Name = "Baskılı Beyaz Tişört", Price = 30, StockAmount = 20, IsActive= true, IsHome=false, CategoryId=1 ,Image="1.jpg"
                },

                new Product()
                {
                    Name = "Balon Kol Beyaz Bluz",
                    Description = "-Beli lastiklidir." +
                    "-Kolay ütülenebilir kumaşa  sahiptir." ,
                    Price = 70, StockAmount = 40, IsActive= true, IsHome=false, CategoryId=2 , Image="5.jpg"
                },

                new Product()
                {
                    Name = "Siyah Kumaş Pantolon",
                    Description = "İşe giderken kurtarıcı parçanız.",
                    Price = 90, StockAmount = 15, IsActive= true, IsHome=true, CategoryId=4 , Image="4.jpg"
                },

                new Product()
                {
                    Name = "Şifon Siyah Elbise",
                    Description = "-Midi Boy " +
                    "-Rahat Kesim " +
                    "-Şifon " ,
                    Price = 80, StockAmount = 20, IsActive= true, IsHome=false, CategoryId=6 , Image="2.jpg"
                },

                new Product()
                {
                    Name = "Mavi Tulum",Description ="Rahat spor tulum", Price = 75, StockAmount = 20, IsActive= true, IsHome=true, CategoryId=7 , Image="3.jpg"
                },
               
                new Product()
                {
                    Name = "Kot şort",
                    Description = "-Mini Boy " +
                    "-Rahat Kesim ",
                    Price = 60, StockAmount = 30, IsActive= true, IsHome=false, CategoryId=5 , Image="6.jpg"
                }

            };

            foreach (var product in productList)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}