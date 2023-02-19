namespace api_pizza.Entities
{
    public class Pizza
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public int ParentId { get; set; }
        public int Category { get; set; }
        public List<int> Size { get; set; }
        public List<double> Price { get; set; }
        public int Rating { get; set; }
        public List<int> Dough { get; set; }
    }
}