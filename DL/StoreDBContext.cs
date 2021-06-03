using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using models;

namespace DL
{
    public class StoreDBContext : DbContext
    {
        /// <summary>
        /// Passes in connection string
        /// </summary>
        /// <param name="options"></param>
        public StoreDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public StoreDBContext()
        {

        }

        /// <summary>
        /// Declaring Entities
        /// </summary>
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .Property(appUser => appUser.AppUserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Products>()
                .Property(products => products.ProductsId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>()
                .Property(location => location.LocationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<LineItem>()
                .Property(lineItem => lineItem.LineItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(order => order.OrderId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>()
                .Property(inventory => inventory.InventoryId).ValueGeneratedOnAdd();
        }
    }
}
