using System.Text.Json.Serialization;

namespace RecruitmentTask.Dto
{
    /// <summary>Invoice data transfer object</summary>
    public class InvoiceDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Invoice number</summary>
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>Invoice name</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>Invoice created date</summary>
        [JsonPropertyName("invoiceDate")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>Payment date</summary>
        [JsonPropertyName("paymentDate")]
        public DateTime PaymentDate { get; set; }

        /// <summary>Account number</summary>
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>List of invoice items</summary>
        [JsonPropertyName("invoiceItems")]
        public IEnumerable<InvoiceItemDto> InvoiceItems { get; set; }

        /// <summary>Total amount</summary>
        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>Constructor</summary>
        public InvoiceDto()
        {
            Name = string.Empty;
            Number = string.Empty;
            AccountNumber = string.Empty;
            InvoiceItems = new List<InvoiceItemDto>();
        }
    }
}
