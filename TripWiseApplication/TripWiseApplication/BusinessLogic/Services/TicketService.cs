using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.Services;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async void AddTicket(Ticket ticket) 
    {
        await _unitOfWork.TicketRepository.AddAsync(ticket);
        _unitOfWork.Save();
    }

    public async void RemoveTicket(int id)
    {
        await _unitOfWork.TicketRepository.RemoveAsync(id);
        _unitOfWork.Save();
    }
}
