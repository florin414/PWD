using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.Services;

public class AccommodationService : IAccommodationService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccommodationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async void AddAccomodation(Accommodation accommodation)
    {
       await _unitOfWork.AccommodationRepository.AddAsync(accommodation);
       _unitOfWork.Save();
    }

    public async void DeleteAccomodationById(int id)
    {
       await _unitOfWork.AccommodationRepository.RemoveAsync(id);
       _unitOfWork.Save();
    }
}
