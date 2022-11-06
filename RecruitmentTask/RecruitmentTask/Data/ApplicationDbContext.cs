using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data.Model;

namespace RecruitmentTask.Data
{
    /// <summary>Application database context</summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>Items db set</summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>Invoices db set</summary>
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>Constructor</summary>
        /// <param name="options">Db context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();

            //DataSeeder.SeedUpdate(this);
        }

        /// <summary>OnModelCreating override method</summary>
        /// <param name="modelBuilder">Model builder options</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .HasMany(x => x.InvoiceItems)
                .WithOne(x => x.Invoice)
                .HasForeignKey(x => x.InvoiceId);
            modelBuilder.Entity<Invoice>()
                .HasData(DataSeeder.Invoices);

            modelBuilder.Entity<Item>()
                .HasMany(x => x.Invoices)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId);
            modelBuilder.Entity<Item>()
                .HasData(DataSeeder.Items);

            modelBuilder.Entity<InvoiceItem>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<InvoiceItem>()
                .HasData(DataSeeder.SeedInvoiceItems());
        }
    }
}
