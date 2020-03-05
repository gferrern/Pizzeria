using System;
namespace pizzeria.Domain{
    public class PizzeriaIngredient{
        public Guid Id {get; set;}
        public Pizzeria Pizza {get;set;}
        public Ingredient Ingredient{get;set;}
    }
}