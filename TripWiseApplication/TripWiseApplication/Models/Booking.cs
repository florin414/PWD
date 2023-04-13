using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Booking")]
public class Booking
{
    [Key]
    public int BookingId { get; set; }
    [Required]
    public double Price { get; set; }
    public bool CheckIn { get; set; } = false;
    public bool CheckOut { get; set; } = false;
    [ForeignKey("AccomodationId")]
    public int? AccomodationId { get; set; }
    public Accommodation? Accomodation { get; set; }

}
