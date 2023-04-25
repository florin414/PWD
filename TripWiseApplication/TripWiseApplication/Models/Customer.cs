using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public bool IsUserAuthenticated { get; set; } = false;
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public ICollection<Ticket>? Tickets { get; set; }
}
