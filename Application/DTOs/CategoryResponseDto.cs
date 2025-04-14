using System.Text.Json.Serialization;

namespace Application.DTOs;

public class CategoriesResponseDto
{
    [JsonPropertyName("Categorias")]
    public List<CategoryDto> Categories { get; set; }
}
