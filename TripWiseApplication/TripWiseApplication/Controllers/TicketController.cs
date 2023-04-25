using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;
public class TicketController : Controller
{
    private readonly ITicketService _ticketService;
    [BindProperty]
    public Ticket Ticket { get; set; }

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        _ticketService.AddTicket(Ticket);
        return View();
    }
}
