using Microsoft.AspNetCore.Mvc;
using ASPCoreFirstApp.Models;
using System.Diagnostics;

namespace ASPCoreFirstApp.Controllers
{
    public class MovieController : Controller
    {

        List <Movie> movies = new List<Movie>{
            new Movie { Id = 1, name = "Inception" },
            new Movie { Id = 2, name = "The Matrix" },
            new Movie { Id = 3, name = "Interstellar" }
        };

        List <Customer> customers = new List<Customer>{
            new Customer { Id = 1, name = "Customer A" },
            new Customer { Id = 2, name = "Customer B" },
            new Customer { Id = 3, name = "Customer C" }
        };

      public IActionResult Details()
      {
        var movie = new Movie() { Id = 1, name = "Inception" };

        var viewModel = new MovieCustomerViewModel
        {
            Movie = movie,
            Customers = customers
        };

        return View(viewModel);
      }


      public IActionResult Index()
      {
        return View(movies);
        }




      // [Route("Movie/released/{year}/{month}")]
      public IActionResult ByRelease(int year, int month)
      {
        return Content($"Released in: {month}/{year}");
      }


public IActionResult Edit(int id)
{
    var movie = movies.FirstOrDefault(m => m.Id == id);
    if (movie == null)
        return NotFound();

    return View(movie);
}


//  [HttpDelete]
public IActionResult Delete(int id)
{
    var movieToRemove = movies.FirstOrDefault(m => m.Id == id);
    if (movieToRemove == null)
        return NotFound();

    movies.Remove(movieToRemove);
    return Content(movieToRemove.name + " deleted");
    // return RedirectToAction("Index");
}



[HttpDelete]
public IActionResult Delete(int id)
{
    var movieToRemove = movies.FirstOrDefault(m => m.Id == id);
    if (movieToRemove == null)
        return NotFound();

    movies.Remove(movieToRemove);
    return Content(movieToRemove.name + " deleted");
    // return RedirectToAction("Index");
}




[HttpPost]
public IActionResult Edit(Movie updatedMovie)
{
    var movie = movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
    if (movie == null)
        return NotFound();

    movie.name = updatedMovie.name;

    return RedirectToAction("Index");
}











      }
}

