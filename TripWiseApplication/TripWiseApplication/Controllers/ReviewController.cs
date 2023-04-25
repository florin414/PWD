using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;
public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;
    [BindProperty]
    public Review Review { get; set; }

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        _reviewService.CreateReview(Review);
        return View();
    }
}

