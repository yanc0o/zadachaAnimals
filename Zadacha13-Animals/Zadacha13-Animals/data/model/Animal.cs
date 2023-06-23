using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha13_Animals.data.model
{
    internal class Animal
    {
        public int Id { get; set; }
        public string AnimalName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public int BreedId
        {
            get; set;
        }
        public Breed Breed
        {
            get; set;
        }
    }
}
