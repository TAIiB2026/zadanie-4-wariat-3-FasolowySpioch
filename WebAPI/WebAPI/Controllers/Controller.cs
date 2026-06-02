using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmyController : ControllerBase
    {
        private static readonly List<Film> _filmy = new List<Film>
        {
            new Film { Id = 1, Tytul = "Incepcja", Cena = 29.99m, DataPremiery = new DateTime(2010, 7, 30) },
            new Film { Id = 2, Tytul = "Interstellar", Cena = 39.99m, DataPremiery = new DateTime(2014, 11, 7) },
            new Film { Id = 3, Tytul = "Gladiator", Cena = 19.99m, DataPremiery = new DateTime(2000, 5, 5) }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Film>> Get() => Ok(_filmy);

        [HttpGet("{id}")]
        public ActionResult<Film> GetById(int id)
        {
            var film = _filmy.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            return Ok(film);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Film nowyFilm)
        {
            if (nowyFilm == null) return BadRequest();

            nowyFilm.Id = _filmy.Any() ? _filmy.Max(f => f.Id) + 1 : 1;
            _filmy.Add(nowyFilm);

            return Ok(true);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Film zaktualizowanyFilm)
        {
            if (zaktualizowanyFilm == null) return BadRequest();

            var film = _filmy.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound(false);

            film.Tytul = zaktualizowanyFilm.Tytul;
            film.Cena = zaktualizowanyFilm.Cena;
            film.DataPremiery = zaktualizowanyFilm.DataPremiery;

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var film = _filmy.FirstOrDefault(f => f.Id == id);
            if (film == null) 
            {
                return NotFound(false);
            }

            _filmy.Remove(film);
            return Ok(true);
        }
    }
}