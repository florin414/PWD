using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Image")]
public class Image
{
    [Key]
    public int Id { get; set; }
    public string Data { get; set; }
    public Accommodation? Accommodation { get; set; }
    [ForeignKey("AccommodationId")]
    public int? AccommodationId { get; set; }
}
