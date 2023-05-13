using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;

[Authorize(Roles = "Administrator,User")]
public class AccomodationController : Controller
{
    private readonly IAccommodationService _accommodationService;
    [BindProperty]
    public Accommodation Accommodation { get; set; }

    public AccomodationController(IAccommodationService accommodationService)
    {
        _accommodationService = accommodationService ?? throw new ArgumentNullException(nameof(accommodationService));
    }

    [Authorize(Roles = "User")]
    [Authorize(Roles = "Administrator")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        _accommodationService.AddAccomodation(Accommodation);
        return View();
    }
}
