using System.Collections.Generic;
using pizzeria.Domain;
using pizzeria.Dtos;
using pizzeria.Infraestructure;

namespace pizzeria.Application
{
    public class IngrdientService : IIngredientService
    {
        private readonly IIngredientRepository _repositoryIngredient;
        public IngrdientService(IIngredientRepository repositoryIngredient)
        {
            _repositoryIngredient = repositoryIngredient;
        }

        public void AddRange(IEnumerable<IngredientFileRead> ingredientFileRead)
        {
            foreach(var ingredient in ingredientFileRead){
                var ing=Ingredient.Create(ingredient);
                _repositoryIngredient.Ingredient.Add(ing);
            }
            _repositoryIngredient.SaveChanges();
        }
    }
}