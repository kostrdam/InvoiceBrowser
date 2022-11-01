using Microsoft.EntityFrameworkCore;

namespace RecruitmentTask.Data
{
    /// <summary>Item model</summary>
    public class Item
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>Price</summary>
        [Precision(19, 4)]
        public decimal Price { get; set; }

        /// <summary>Invoice items</summary>
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
