using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryInfo> DeliveryInfo { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("a604ee7e-aa0e-4ffc-b596-816570a9bc79");
            var product2Id = Guid.Parse("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd");
            var product3Id = Guid.Parse("e66f97c7-6414-423b-9589-8c92a964df62");
            var product4Id = Guid.Parse("ba082277-4b6f-4e86-a922-07353ce4ad13");

            var image1 = new Image
            {
                Id = Guid.Parse("255f76df-5217-4de6-9941-f011ea2042cb"),
                Url = "/img/products/stilllife.jpg",
                ProductId = product1Id
            };

            var image2 = new Image
            {
                Id = Guid.Parse("50182c2e-8bd1-4d57-9c13-d7f231642d5b"),
                Url = "/img/products/portret.jpg",
                ProductId = product2Id
            };

            var image3 = new Image
            {
                Id = Guid.Parse("266ed356-5467-48ac-b1b2-ec3a45ca722a"),
                Url = "/img/products/landscape.jpg",
                ProductId = product3Id
            };

            var image4 = new Image
            {
                Id = Guid.Parse("8acc7169-6d98-456d-803e-9694472ceceb"),
                Url = "/img/products/abstraction.jpg",
                ProductId = product4Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2, image3, image4);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id, "Still Life", 100, "Photography, 2000 x 3000 px, 4,5 Mb Tiff"), 
                new Product(product2Id, "Portret", 200, "Photography, 2000 x 3000 px, 4,8 Mb Tiff"), 
                new Product(product3Id, "Landscape", 300, "Photography, 2000 x 3000 px, 3,5 Mb Tiff"), 
                new Product(product4Id, "Abstraction", 400, "Photography, 2000 x 3000 px, 2,5 Mb Tiff"), 
            });
        }
    }
}
