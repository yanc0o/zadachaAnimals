using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadacha13_Animals.data;
using Zadacha13_Animals.data.model;

namespace Zadacha13_Animals.logic
{
    internal class AnimalLogic
    {
        private AnimalsContext _animalsDbContext = new AnimalsContext();

        public Animal Get(int id)
        {
            Animal findedAnimal = _animalsDbContext.Animals.Find(id);
            if (findedAnimal != null)
            {
                _animalsDbContext.Entry(findedAnimal).Reference(x => x.Breed).Load();
            }
            return findedAnimal;
        }
        public List<Animal> GetAll()
        {
            return _animalsDbContext.Animals.Include("Breed").ToList(); 
        }
        public void Create(Animal animal)
        {
            _animalsDbContext.Animals.Add(animal);
            _animalsDbContext.SaveChanges();
        }
        public void Update(int id, Animal animal)
        {
            Animal findedAnimal = _animalsDbContext.Animals.Find(id);
            if (findedAnimal == null)
            {
                return;
            }
            findedAnimal.Age = animal.Age;
            findedAnimal.AnimalName = animal.AnimalName;
            findedAnimal.BreedId = animal.BreedId;
            _animalsDbContext.SaveChanges(); 
        }
        public void Delete(int id)
        {
            Animal findedAnimal = _animalsDbContext.Animals.Find(id);
            _animalsDbContext.Animals.Remove(findedAnimal);
            _animalsDbContext.SaveChanges(); 
        }
}
    
  
}
