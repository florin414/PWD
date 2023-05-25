using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;

public interface IAccommodationService
{
    void AddAccomodation(Accommodation accommodation);
    void DeleteAccomodationById(int id);
    IEnumerable<Accommodation> GetAll();

}
