using System.Text.Json.Serialization;

namespace RecruitmentTask.Dto
{
    /// <summary>Item data transfer object</summary>
    public class InvoiceItemDto
    {
        /// <summary>Id</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Item name</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>Price</summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>Quantity</summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>Constructor</summary>
        public InvoiceItemDto()
        {
            Name = string.Empty;
        }
    }
}
