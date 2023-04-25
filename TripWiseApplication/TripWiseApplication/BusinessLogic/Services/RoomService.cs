using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.Services;

public class RoomService : IRoomService
{
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async void AddRoom(Room room) 
    {
        await _unitOfWork.RoomRepository.AddAsync(room);
        _unitOfWork.Save();
    }

    public async void RemoveRoom(int id) 
    {
        await _unitOfWork.RoomRepository.RemoveAsync(id);
        _unitOfWork.Save();
    }
}
