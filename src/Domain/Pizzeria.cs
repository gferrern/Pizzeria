using System;
using pizzeria.Dtos;
using System.IO;

namespace pizzeria.Domain
{
    public class Pizzeria
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public static Pizzeria Create(PizzeriaDTO p){
            var pizzeria = new Pizzeria();
            pizzeria.Id = Guid.NewGuid();
            pizzeria.Name = p.Name;
            using (var memoryStream = new MemoryStream(p.Image))
            {
                pizzeria.Image = memoryStream.ToArray();
            }
            return pizzeria;
        }
    }
}