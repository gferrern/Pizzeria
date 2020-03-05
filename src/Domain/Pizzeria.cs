using System;
using pizzeria.Dtos;
using System.Collections.Generic;

namespace pizzeria.Domain
{
    public class Pizzeria
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HashSet<Image> Images{get;set;}
        public HashSet<PizzeriaIngredient> Ingredients {get;set;}

        public static Pizzeria Create(PizzeriaDTO p){
            var pizzeria = new Pizzeria();
            pizzeria.Id = Guid.NewGuid();
            pizzeria.Name = p.Name;
           
            return pizzeria;
        }
    }
}