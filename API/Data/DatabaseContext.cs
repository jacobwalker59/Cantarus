using Microsoft.EntityFrameworkCore;
using SupermarketCheckout;

namespace API
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<ProductItem> ProductItems {get;set;}
        public DbSet<ProductDeal> ProductDeals{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<ProductItem>().HasMany<ProductDeal>().WithOne(x => x.ProductItem)
            // .HasForeignKey(x => x.ProductItemId);

            modelBuilder.Entity<ProductDeal>().HasOne<ProductItem>(e => e.ProductItem).WithMany(x => x.ProductDeals)
            .HasForeignKey(x => x.ProductItemId);

            modelBuilder.Entity<ProductItem>()
            .HasData(
                new ProductItem{Id =1, ProductName="Apples", ProductPrice= 1.00f}
            );
            modelBuilder.Entity<ProductDeal>()
            .HasData(
                new ProductDeal{Id =1, Count=3, Price= 2.00f, ProductItemId =1},
                new ProductDeal{Id =2, Count=7, Price= 4.20f, ProductItemId =1}
            );

        }
    }
}