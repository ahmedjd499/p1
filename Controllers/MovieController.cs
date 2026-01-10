using Microsoft.AspNetCore.Mvc;
using ASPCoreFirstApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace ASPCoreFirstApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly string _moviesFilePath = "data/movies.json";

        private List<Movie> LoadMovies()
        {
            if (!System.IO.File.Exists(_moviesFilePath))
                return new List<Movie>();

            var json = System.IO.File.ReadAllText(_moviesFilePath);
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        private void SaveMovies(List<Movie> movies)
        {
            var json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_moviesFilePath, json);
        }

        List <Customer> customers = new List<Customer>{
            new Customer { Id = 1, name = "Customer A" },
            new Customer { Id = 2, name = "Customer B" },
            new Customer { Id = 3, name = "Customer C" }
        };

      public IActionResult Details()
      {
        var movies = LoadMovies();
        var movie = movies.FirstOrDefault(m => m.Id == 1) ?? new Movie() { Id = 1, name = "Inception" };

        var viewModel = new MovieCustomerViewModel
        {
            Movie = movie,
            Customers = customers
        };

        return View(viewModel);
      }


      public IActionResult Index()
      {
        var movies = LoadMovies();
        return View(movies);
        }




      // [Route("Movie/released/{year}/{month}")]
      public IActionResult ByRelease(int year, int month)
      {
        return Content($"Released in: {month}/{year}");
      }


        public IActionResult Edit(int id)
        {
            var movies = LoadMovies();
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }


        //  [HttpDelete]
        public IActionResult Delete(int id)
        {
            var movies = LoadMovies();
            var movieToRemove = movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove == null)
                return NotFound();

            movies.Remove(movieToRemove);
            SaveMovies(movies);
           // return Content(movieToRemove.name + " deleted");
             return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete2(int id)
        {
            var movies = LoadMovies();
            var movieToRemove = movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove == null)
                return NotFound();

            movies.Remove(movieToRemove);
            SaveMovies(movies);
            return Content(movieToRemove.name + " deleted");
            // return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            var movies = LoadMovies();
            var movie = movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
            if (movie == null)
                return NotFound();

            movie.name = updatedMovie.name;
            SaveMovies(movies);

            return RedirectToAction("Index");
        }











      }
}

