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

    public class SearchController : ControllerBase
    {
        private Safari2Context db { get; set; }

        public SearchController()
        {
            this.db = new Safari2Context();
        }

        [HttpGet]
        public ActionResult<SeenAnimal> GetBySpecies([FromQuery] string species, string location)
        {
            if (species != null)
            {
                var animal = this.db.SeenAnimals.Where(w => w.Species == species).First();
                return animal;

                // https://localhost:5001/api/search?species=Lion

            }
            else if (location != null)
            {
                var animal = db.SeenAnimals.Where(w => w.LocationOfLastSeen == location).First();
                return animal;

                // https://localhost:5001/api/search?location=Outside
            }
            else
            {

                return null;
            }

        }

    }

}