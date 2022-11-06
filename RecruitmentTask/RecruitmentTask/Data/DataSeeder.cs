using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Data.Model;

namespace RecruitmentTask.Data
{
    public static class DataSeeder
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item { Id = 1, Name = "Guitar", Price = 1000 },
            new Item { Id = 2, Name = "Book", Price = 50 },
            new Item { Id = 3, Name = "Tomato", Price = 2 },
            new Item { Id = 4, Name = "Shoes", Price = 200 },
            new Item { Id = 5, Name = "Jacket", Price = 500 }
        };

        public static List<Invoice> Invoices = new List<Invoice>()
        {
            new Invoice
            {
                Id = 1,
                Name = "Invoice 1",
                Number = "FV 03/11/2022",
                AccountNumber = "1234",
                InvoiceDate = DateTime.Now,
                PaymentDate = DateTime.Now.AddDays(7),
            },
            new Invoice
            {
                Id = 2,
                Name = "Invoice 2",
                Number = "FV 25/04/2012",
                AccountNumber = "4321",
                InvoiceDate = new DateTime(2012, 04, 25),
                PaymentDate = new DateTime(2012, 04, 30)
            },
            new Invoice
            {
                Id = 3,
                Name = "Invoice 3",
                Number = "FV 25/04/2032",
                AccountNumber = "2233",
                InvoiceDate = new DateTime(2032, 04, 25),
                PaymentDate = new DateTime(2032, 04, 25),
            }

        };

        public static IEnumerable<InvoiceItem> SeedInvoiceItems()
        {
            var counter = 0;
            return new List<InvoiceItem>()
            {
                //invoice 1:
                AddItemToInvoice(ref counter, Invoices[0], Items[0], 1),
                AddItemToInvoice(ref counter, Invoices[0], Items[1], 2),

                //invoice 2:
                AddItemToInvoice(ref counter, Invoices[1], Items[1], 3),
                AddItemToInvoice(ref counter, Invoices[1], Items[2], 7),

                //invoice 3:
                AddItemToInvoice(ref counter, Invoices[2], Items[3], 12),
                AddItemToInvoice(ref counter, Invoices[2], Items[4], 5)
            };
        }

        private static InvoiceItem AddItemToInvoice(ref int counter, Invoice invoice, Item item, int quantity)
        {
            counter++;
            return new InvoiceItem { Id = counter, InvoiceId = invoice.Id, ItemId = item.Id, Quantity = quantity};
        }

        public static void SeedUpdate(ApplicationDbContext context)
        {
            var invoices = context.Invoices
                .Include(i => i.InvoiceItems)
                .ThenInclude(i => i.Item)
                .ToList();

            foreach (var invoice in invoices)
            {
                invoice.TotalAmount = invoice.InvoiceItems.Sum(x => x.Item.Price * x.Quantity);
            }

            context.SaveChanges();
        }
    }
}
