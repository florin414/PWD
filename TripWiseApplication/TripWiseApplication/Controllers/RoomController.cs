using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;
public class RoomController : Controller
{
    private readonly IRoomService _roomService;
    [BindProperty]
    public Room Room { get; set; }

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult OnPostRoomAsync()
    {
        _roomService.AddRoom(Room);
        return View();
    }
}
