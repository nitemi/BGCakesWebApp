namespace BGCakes.Models
{
    public class CakeIngredient
    {
        public int CakeId { get; set; }
        public Cake Cake{ get; set; }
        public int IngredientId {  get; set; }
  
        public Ingredient Ingredient { get; set; }
      
    }
}
