namespace RecruitmentTask.Data
{
    public class DataSeeder
    {
        public IEnumerable<Item> SeedItems()
        {
            var items = new List<Item>();
            items.Add(new Item { Name = "Guitar", Price = 1000 });
            items.Add(new Item { Name = "Book", Price = 50 });
            items.Add(new Item { Name = "Tomato", Price = 2 });
            items.Add(new Item { Name = "Shoes", Price = 200 });
            items.Add(new Item { Name = "Jacket", Price = 500 });

            return items;
        }

        public IEnumerable<Invoice> SeedInvoices(List<Item> items)
        {
            var invoices = new List<Invoice>();
            invoices.Add(new Invoice
            {
                Name = "Invoice 1",
                Number = "FV 1/10/2022",
                AccountNumber = "1234",
                InvoiceDate = DateTime.Now,
                PaymentDate = DateTime.Now.AddDays(7),
                Items = new List<Item> { items[0], items[1] }
            });

            invoices.Add(new Invoice
            {
                Name = "Invoice 2",
                Number = "FV 2/10/2022",
                AccountNumber = "4321",
                InvoiceDate = DateTime.Now.AddDays(1),
                PaymentDate = DateTime.Now.AddDays(8),
                Items = new List<Item> { items[1], items[2], items[3] }
            });

            invoices.Add(new Invoice
            {
                Name = "Invoice 3",
                Number = "FV 3/10/2022",
                AccountNumber = "2233",
                InvoiceDate = DateTime.Now.AddDays(2),
                PaymentDate = DateTime.Now.AddDays(9),
                Items = new List<Item> { items[3], items[4], items[4] }
            });
            return invoices;
        }
    }
}
