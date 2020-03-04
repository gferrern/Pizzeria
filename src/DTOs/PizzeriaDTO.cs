using System.ComponentModel.DataAnnotations;

namespace pizzeria.Dtos
{
    public class PizzeriaDTO
    {
        [Required]
        public string Name {get; set; }
        [Required]
        public byte[] Image { get; set; }

    }
}
