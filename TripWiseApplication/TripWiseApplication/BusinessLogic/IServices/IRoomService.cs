using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;

public interface IRoomService
{
    void AddRoom(Room room);
    void RemoveRoom(int id);
}
