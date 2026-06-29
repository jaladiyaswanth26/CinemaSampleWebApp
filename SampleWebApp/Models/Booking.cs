namespace SampleWebApp.Models;

public class Booking
{
    public Movie Movie { get; set; } = new();
    public int NumberOfTickets { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string SeatPreference { get; set; } = string.Empty;
    public DateTime BookingDate { get; set; }
}