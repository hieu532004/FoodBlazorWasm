using ASM_C_6.Models;
using Microsoft.EntityFrameworkCore;
namespace ASM_C_6.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductItemProduct> ProductItemsProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> invoiceDetails { get; set; }
        public DbSet<Shipping> shippings { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring one-to-many relationship between Customer and Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.Customer_Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuring one-to-many relationship between Employee and Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Employee)
                .WithMany(e => e.Invoices)
                .HasForeignKey(i => i.Employee_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
