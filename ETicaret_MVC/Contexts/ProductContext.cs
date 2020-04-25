using ETicaret_MVC.Entities;
using ETicaret_MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ETicaret_MVC.Contexts
{
    public class ProductContext : IdentityDbContext<ApplicationUser>
    {
        public ProductContext() : base("DefaultConnection")
        {
            
        }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderLine> OrderLines { get; set; }

    }
}