using System;

namespace pizzeria.Domain
{
    public class Pizzeria
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}