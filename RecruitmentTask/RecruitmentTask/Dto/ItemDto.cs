namespace RecruitmentTask.Dto
{
    /// <summary>Item data transfer object</summary>
    public class ItemDto
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Name</summary>
        public string Name { get; set; }

        /// <summary>Price</summary>
        public decimal Price { get; set; }

        /// <summary>Invoice items</summary>
        public IEnumerable<InvoiceDto> Invoices { get; set; }

        /// <summary>Constructor</summary>
        public ItemDto()
        {
            Invoices = new List<InvoiceDto>();
        }
    }
}
