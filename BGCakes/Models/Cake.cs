namespace BGCakes.Models
{
    public class Cake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public List<CakeIngredient>? CakeIngredients { get; set; }
      
    }
}
