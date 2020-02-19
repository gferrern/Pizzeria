using System;
using System.Data.Entity;
using pizzeria.Domain;

namespace pizzeria.Infraestructure{
    public class PizzeriaContext:DbContext
    {
        public PizzeriaContext(Parameters)
        {
            this.SaveChanges()
        }
        public DbSet<User> User{get; set;}
    }
}