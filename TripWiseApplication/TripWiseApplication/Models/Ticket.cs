using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [Required]
    public double Price { get; set; }
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    [ForeignKey("BookingId")]
    public int? BookingId { get; set; }
    public Booking? Booking { get; set; }
}
