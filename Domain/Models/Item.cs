namespace Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Element { get; set; }
        public int Value { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
