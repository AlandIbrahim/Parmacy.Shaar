using Microsoft.EntityFrameworkCore;
using Parmacy.Shaar.Models;
using Parmacy.Shaar.Models.ViewModels;

namespace Parmacy.Shaar.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerPayment> customer_Payments { get; set; }
        public DbSet<Models.Delegate> delegates { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<ItemInfo> items_info { get; set; }
        public DbSet<ItemPurchase> items_purchase { get; set; }
        public DbSet<ItemSale> items_sale { get; set; }
        //public DbSet<Item_Sell> items_sell { get; set; }
        public DbSet<TransferCompany> transfer_Companies { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<SellInvoice>sellInvoices { get; set; }
        public DbSet<BuyInvoice> buyInvoices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemInfo>().HasKey(k => new { k.Expiration_Date, k.Item_Id });
        }
        public DbSet<Parmacy.Shaar.Models.ViewModels.LoginVM> LoginVM { get; set; } = default!;
    }
}
