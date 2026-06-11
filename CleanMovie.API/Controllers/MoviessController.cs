using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanMovie.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class MoviessController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviessController(IMovieService service)
        {
            _service = service;
        }

        // GET: api/<MoviessController>
        [Route("GetAll")]
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            var moviesFromService = _service.GetAllMovies();
            return Ok(moviesFromService);
        }

        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            var createdMovie = _service.CreateMovie(movie);
            return Ok(createdMovie);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Movie> MovieGetById(int id)
        {
            var moviesId = _service.GetMovieById(id);
            if(moviesId == null)
            {
                return NotFound();
            }
            return Ok(moviesId);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie(int id, Movie obj)
        {
            if(id != obj.Id)
            {
                return BadRequest("Movie Id mismatch!");
            }
            _service.Entry(obj).State = EntityState.Modified;
            try
            {
                await _service.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!MovieExists(id))
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult MovieDelete(int id)
        {
            var moviesId = _service.GetMovieById(id);
			if(moviesId == null)
			{
				return NotFound();
			}
            _service.Delete(id);
            return NoContent();
        }
    }
}
