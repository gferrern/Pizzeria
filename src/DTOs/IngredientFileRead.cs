using System.ComponentModel.DataAnnotations;

namespace pizzeria.Dtos
{
    public class IngredientFileRead
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

