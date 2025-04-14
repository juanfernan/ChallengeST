using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Seed;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Categories.Any())
        {
            var data = new List<Category>
            {
                new()
                {
                    CategoryName = "Iluminacion",
                    Items = new List<Item>
                    {
                        new() { Element = "Lámpara Led de 5w", Value = 5 },
                        new() { Element = "Lámpara Led de 10w", Value = 10 },
                        new() { Element = "Lámpara Incandescente 40w", Value = 40 },
                        new() { Element = "Lámpara Incandescente de 100w", Value = 100 },
                        new() { Element = "Lámpara Incandescente de 200w", Value = 200 }
                    }
                },
                new()
                {
                    CategoryName = "Refrigeracion",
                    Items = new List<Item>
                    {
                        new() { Element = "Heladera", Value = 1000 },
                        new() { Element = "Freezer", Value = 1500 }
                    }
                }
            };

            context.Categories.AddRange(data);
            context.SaveChanges();
        }
    }
}
