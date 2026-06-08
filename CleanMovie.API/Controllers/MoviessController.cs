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
            var Movie = _service.CreateMovie(movie);
            return Ok(Movie);
        }
        
        [HttpGet]
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
        public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie obj)
        {
            if(id != obj.Id)
            {
                return BadRequest("Movie Id mismatch!");
            }
            _service.Entry(obj).State = EntityState.Modified;
            _service.SaveChanges();
        }

        [HttpPost]
        public ActionResult<Movie> MovieDelete(int id)
        {
            var moviesId = _service.GetMovieById(id);
            _service.Delete(id);
            return Ok(moviesId);
        }
    }
}
