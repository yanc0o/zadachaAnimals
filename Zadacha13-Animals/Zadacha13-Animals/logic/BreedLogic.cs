using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadacha13_Animals.data;
using Zadacha13_Animals.data.model;

namespace Zadacha13_Animals.logic
{
    internal class BreedLogic
    {
        private AnimalsContext _animalsDbContext = new AnimalsContext();

        public List<Breed> GetAllBreeds()
        {
            return _animalsDbContext.Breeds.ToList();
        }
        public string GetBreedById(int id)
        {
            return _animalsDbContext.Breeds.Find(id).BreedName;
        }
    }
}
