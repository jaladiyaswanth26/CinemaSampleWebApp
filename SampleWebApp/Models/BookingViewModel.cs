using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Models;

public class BookingViewModel
{
    public int MovieId { get; set; }
    public string MovieTitle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Number of tickets is required")]
    [Range(1, 10, ErrorMessage = "You can book between 1 and 10 tickets")]
    public int NumberOfTickets { get; set; }

    [Required(ErrorMessage = "Your name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string CustomerEmail { get; set; } = string.Empty;

    public string? SeatPreference { get; set; }
}