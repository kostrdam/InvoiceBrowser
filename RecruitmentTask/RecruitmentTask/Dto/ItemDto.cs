using System.Text.Json.Serialization;

namespace RecruitmentTask.Dto
{
    /// <summary>Item data transfer object</summary>
    public class ItemDto
    {
        /// <summary>Id</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Name</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        /// <summary>Price</summary>
        public decimal Price { get; set; }

        /// <summary>Constructor</summary>
        public ItemDto()
        {
            Name = string.Empty;
        }
    }
}
