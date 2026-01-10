using Microsoft.AspNetCore.Mvc;
using ASPCoreFirstApp.Models;
using System.Diagnostics;

namespace ASPCoreFirstApp.Controllers
{
    public class MovieController : Controller
    {
      public IActionResult Index()
      {
        List <Movie> movies = new List<Movie>{
            new Movie { Id = 1, name = "Inception" },
            new Movie { Id = 2, name = "The Matrix" },
            new Movie { Id = 3, name = "Interstellar" }
        };
        return View(movies);
        }

      public IActionResult Edit(int id)
      {
        return Content($"Movie ID: {id}");
      }

      // [Route("Movie/released/{year}/{month}")]
      public IActionResult ByRelease(int year, int month)
      {
        return Content($"Released in: {month}/{year}");
      }

      }
}

