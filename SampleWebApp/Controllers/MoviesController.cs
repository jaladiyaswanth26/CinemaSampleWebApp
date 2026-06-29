using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Models;
using System.Diagnostics;

namespace SampleWebApp.Controllers;

public class MoviesController : Controller
{
    // In-memory list of movies
    private static List<Movie> _movies = new()
    {
        new Movie
        {
            Id = 1,
            Title = "Inception",
            Genre = "Sci-Fi",
            Description = "A thief who steals corporate secrets through the use of dream-sharing technology.",
            Rating = 8.8,
            Showtimes = new List<string> { "10:00 AM", "1:30 PM", "4:45 PM", "8:00 PM" },
            PosterUrl = "https://via.placeholder.com/300x450/1a1a2e/ffffff?text=Inception"
        },
        new Movie
        {
            Id = 2,
            Title = "The Dark Knight",
            Genre = "Action",
            Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham.",
            Rating = 9.0,
            Showtimes = new List<string> { "11:15 AM", "2:45 PM", "6:30 PM", "9:15 PM" },
            PosterUrl = "https://via.placeholder.com/300x450/1a1a2e/ffffff?text=Dark+Knight"
        },
        new Movie
        {
            Id = 3,
            Title = "Interstellar",
            Genre = "Adventure",
            Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
            Rating = 8.6,
            Showtimes = new List<string> { "9:30 AM", "12:45 PM", "4:00 PM", "7:30 PM" },
            PosterUrl = "https://via.placeholder.com/300x450/1a1a2e/ffffff?text=Interstellar"
        }
    };

    // GET: /Movies
    public IActionResult Index()
    {
        return View(_movies);
    }

    // GET: /Movies/Details/{id}
    public IActionResult Details(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
            return NotFound();
        return View(movie);
    }

    // GET: /Movies/Book/{id}
    public IActionResult Book(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
            return NotFound();

        var viewModel = new BookingViewModel
        {
            MovieId = movie.Id,
            MovieTitle = movie.Title,
            NumberOfTickets = 1,
            CustomerName = "",
            CustomerEmail = "",
            SeatPreference = ""
        };
        return View(viewModel);
    }

    // POST: /Movies/Book
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Book(BookingViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Re-populate movie title for display
            var movie = _movies.FirstOrDefault(m => m.Id == model.MovieId);
            if (movie != null)
                model.MovieTitle = movie.Title;
            return View(model);
        }

        // In a real app, save booking to database
        // For demo, we just redirect to confirmation page
        return RedirectToAction("Confirmation", new { 
            movieId = model.MovieId, 
            tickets = model.NumberOfTickets,
            name = model.CustomerName,
            email = model.CustomerEmail,
            seat = model.SeatPreference
        });
    }

    // GET: /Movies/Confirmation
    public IActionResult Confirmation(int movieId, int tickets, string name, string email, string seat)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == movieId);
        if (movie == null)
            return NotFound();

        var booking = new Booking
        {
            Movie = movie,
            NumberOfTickets = tickets,
            CustomerName = name,
            CustomerEmail = email,
            SeatPreference = seat,
            BookingDate = DateTime.Now
        };
        return View(booking);
    }
}