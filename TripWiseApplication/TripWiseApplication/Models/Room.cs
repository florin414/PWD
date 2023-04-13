using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Room")]
public class Room
{
    [Key]
    public int RoomId { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    public int RoomType { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}
