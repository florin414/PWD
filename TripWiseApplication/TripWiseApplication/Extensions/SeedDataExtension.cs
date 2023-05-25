using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TripWiseApplication.Models;

namespace TripWiseApplication.Extensions;

public static class SeedDataExtension
{
    public static void SeedUsers(this ModelBuilder builder)
    {
        var hasher = new PasswordHasher<IdentityUser>();
        builder
            .Entity<IdentityUser>()
            .HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    UserName = "Florin",
                    NormalizedUserName = "FLORIN",
                    Email = "florin@gmail.com",
                    NormalizedEmail = "FLORIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                    UserName = "Alin",
                    NormalizedUserName = "ALIN",
                    Email = "alin@gmail.com",
                    NormalizedEmail = "ALIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "9a27620-a44f-4543-9dk6-0993d048sia7",
                    UserName = "Bogdan",
                    NormalizedUserName = "BOGDAN",
                    Email = "bogdan@gmail.com",
                    NormalizedEmail = "BOGDAN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pass_2002"),
                    LockoutEnabled = true,
                    EmailConfirmed = true,
                }
            );
    }

    public static void SeedRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
                new IdentityRole()
                {
                    Id = "3",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            );
    }

    public static void SeedUserRoles(this ModelBuilder builder)
    {
        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    RoleId = "1"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "9c44780-a24d-4543-9cc6-0993d048aacu7",
                    RoleId = "2"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "9a27620-a44f-4543-9dk6-0993d048sia7",
                    RoleId = "3"
                }
            );
    }

    public static void SeedRooms(this ModelBuilder builder)
    {
        var rooms = new Faker<Room>()
            .RuleFor(x => x.RoomId, f => f.IndexFaker + 1)
            .RuleFor(x => x.Capacity, f => f.Random.Int(1, 3))
            .RuleFor(x => x.RoomType, f => (RoomType)f.Random.Int(0, 2));

        builder.Entity<Room>().HasData(rooms.Generate(100));
    }

    public static void SeedReviews(this ModelBuilder builder)
    {
        var reviews = new Faker<Review>()
            .RuleFor(x => x.ReviewId, f => f.IndexFaker + 1)
            .RuleFor(x => x.Comment, f => f.Rant.Review("accommodation"))
            .RuleFor(x => x.RoomId, f => f.Random.Int(1,100));            

        builder.Entity<Review>().HasData(reviews.Generate(1000));
    }

    public static void SeedAccommodations(this ModelBuilder builder)
    {
        var accommodations = new Faker<Accommodation>()
            .RuleFor(x => x.Address, f => f.Address.FullAddress())
            .RuleFor(x => x.AccommodationId, f => f.IndexFaker + 1)
            .RuleFor(x => x.RoomId, f => f.Random.Int(1, 100));

        builder.Entity<Accommodation>().HasData(accommodations.Generate(100));
    }

    public static void SeedImages(this ModelBuilder builder)
    {
        var images = new Faker<Image>()
            .RuleFor(x => x.Id, f => f.IndexFaker + 1)
            .RuleFor(x => x.AccommodationId, f => f.IndexFaker + 1)
            .RuleFor(x => x.Data, f => f.Image.PicsumUrl());

        builder.Entity<Image>().HasData(images.Generate(100));
    }
}
