using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.Dtos
{
    public class PizzeriaDTO
    {
        [Required]
        public string Name {get; set; }
        [Required]
        public Guid Image { get; set; }

        public HashSet<Guid> Ingredients{get;set;}

    }
}
