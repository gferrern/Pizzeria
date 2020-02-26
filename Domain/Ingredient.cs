using System;
using pizzeria.Dtos;
namespace pizzeria.Domain{
    public class Ingredient {
         public Guid Id{get;set;}
        public string Name {get;set;}
        public decimal Price{get;set;}
       public static Ingredient Create(IngredientFileRead ingredientFileRead) {
           var ingredient=new Ingredient();
                       ingredient.Id = Guid.NewGuid();
                       ingredient.Name =ingredientFileRead.Name;
                       ingredient.Price =ingredientFileRead.Price;
                       return ingredient;
       } 
       
       
       }
}