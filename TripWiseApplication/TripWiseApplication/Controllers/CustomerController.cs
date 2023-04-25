using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;

namespace TripWiseApplication.Controllers;
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignInUser()
    {
        _customerService.Login(Email, Password);
        return View();
    }
}
