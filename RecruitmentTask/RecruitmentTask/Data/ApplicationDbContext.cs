using Microsoft.EntityFrameworkCore;

namespace RecruitmentTask.Data
{
    /// <summary>Application database context</summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>Items db set</summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>Invoices db set</summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>Constructor</summary>
        /// <param name="options">Db context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
            //SeedDb();
        }

        /// <summary>OnModelCreating override method</summary>
        /// <param name="modelBuilder">Model builder options</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Item>()
                .HasKey(x => x.Id);
        }

        /// <summary>Seed database</summary>
        private void SeedDb()
        {
            var seeder = new DataSeeder();
            var items = seeder.SeedItems();
            var invoices = seeder.SeedInvoices(items.ToList());
            Items.AddRange(items);
            Invoices.AddRange(invoices);
            SaveChanges();
        }
    }
}
