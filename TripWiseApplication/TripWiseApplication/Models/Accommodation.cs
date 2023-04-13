﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripWiseApplication.Models;

[Table("Accommodation")]
public class Accommodation
{
    [Key]
    public int AccommodationId { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int DurationOfStay { get; set; }
    [ForeignKey("RoomId")]
    public int? RoomId { get; set; }
    public Room? Room { get; set; }
}
