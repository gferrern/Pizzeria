using pizzeria.Dtos;
using System;
namespace pizzeria.Application
{
    public interface IIngredientService
    {
        void Upload(IngredientFileRead ingredientFileRead);
    }
}