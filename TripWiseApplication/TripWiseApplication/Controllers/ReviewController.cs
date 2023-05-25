using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;

public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;
    private readonly IAccommodationService _accommodationService;
    private readonly IImageService _imageService;

    [BindProperty]
    public Review Review { get; set; }

    public ReviewController(
        IReviewService reviewService,
        IAccommodationService accommodationService,
        IImageService imageService
    )
    {
        _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        _accommodationService =
            accommodationService ?? throw new ArgumentNullException(nameof(accommodationService));
        _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
    }

    [HttpGet]
    public IActionResult Index(int id)
    {
        var reviews = _reviewService.GetAllReviewByRoomId(id);
        var accommodation = _accommodationService
            .GetAll()
            .FirstOrDefault(x => x.AccommodationId == id);
        var image = _imageService.GetAll().FirstOrDefault(x =>x .AccommodationId == id);

        return View((reviews, accommodation, image));
    }

    [HttpPost]
    public IActionResult Create()
    {
        _reviewService.CreateReview(Review);
        return View();
    }
}
