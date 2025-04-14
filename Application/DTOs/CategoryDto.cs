using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class CategoryDto
    {
        [JsonPropertyName("categoria")]
        public string Category { get; set; }

        [JsonPropertyName("item")]
        public List<ItemDto> Items { get; set; }
    }
}
