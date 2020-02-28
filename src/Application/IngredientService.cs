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


        public void Upload(IngredientFileRead ingredientFileRead)
        {
            var ingredient = Ingredient.Create(ingredientFileRead);
            _repositoryIngredient.Ingredient.Add(ingredient);
            _repositoryIngredient.SaveChanges();

        }

    }
}