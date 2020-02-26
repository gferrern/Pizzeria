using System;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.Dtos {
    public class IngredientFileRead {
                [Required][MaxLength(40)]
        public string Name {get;set;}
                [Required]
        public decimal Price{get;set;}

    }
}

