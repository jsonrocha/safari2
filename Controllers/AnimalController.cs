using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safari2;

namespace Safari2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private Safari2Context db { get; set; }

        public AnimalController()
        {
            this.db = new Safari2Context();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeenAnimal>> Get()
        {
            return this.db.SeenAnimals;
        }

        [HttpPost]
        public ActionResult<SeenAnimal> Post([FromBody] string species)
        {
            var animal = new SeenAnimal
            {
                Species = species,
                LocationOfLastSeen = "Africa",
            };

            this.db.SeenAnimals.Add(animal);

            this.db.SaveChanges();

            return animal;

        }

        [HttpPut("{species}")]
        public ActionResult<SeenAnimal> Add1TimesSeen(string species)
        {
            var animal = this.db.SeenAnimals.FirstOrDefault(f => f.Species == species);
            animal.CountOfTimesSeen = animal.CountOfTimesSeen + 1;
            this.db.SaveChanges();
            return animal;
        
        // https://localhost:5001/api/animal/Cat
        
        }
        
        [HttpDelete("{species}")]
        public ActionResult<SeenAnimal> Delete(string species)
        {
            var animal = this.db.SeenAnimals.FirstOrDefault(f => f.Species == species);
            db.SeenAnimals.Remove(animal);
            db.SaveChanges();
            Console.Write($"Removed {animal}");
            return animal;
        // https://localhost:5001/api/animal/cat
        
        }

        }
    }