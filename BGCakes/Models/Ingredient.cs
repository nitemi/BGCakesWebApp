namespace BGCakes.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CakeIngredient>? CakeIngredients { get; set; }
    }
}
