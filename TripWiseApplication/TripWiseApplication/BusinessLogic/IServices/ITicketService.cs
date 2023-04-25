using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;

public interface ITicketService
{
    void AddTicket(Ticket ticket);
    void RemoveTicket(int id);
}
