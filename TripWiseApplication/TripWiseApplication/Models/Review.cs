using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Review")]
public class Review
{
    [Key]
    public int ReviewId { get; set; }
    [Required]
    [StringLength(200)]
    public string Comment { get; set; }
    [ForeignKey("RoomId")]
    public int? RoomId { get; set; }
    public Room? Room { get; set; }
}
