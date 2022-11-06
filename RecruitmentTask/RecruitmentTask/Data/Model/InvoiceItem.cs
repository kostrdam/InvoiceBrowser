namespace RecruitmentTask.Data.Model
{
    public class InvoiceItem
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public Invoice? Invoice { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int Quantity { get; set; }
    }
}
