using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadacha13_Animals.data.model;

namespace Zadacha13_Animals.data
{
    internal class AnimalsContext : DbContext
    {
        public AnimalsContext() : base("AnimalsContext")
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
