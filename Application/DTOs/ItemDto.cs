using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class ItemDto
    {
        [JsonPropertyName("elemento")]
        public string Element { get; set; }

        [JsonPropertyName("valor")]
        public int Value { get; set; }
    }
}
