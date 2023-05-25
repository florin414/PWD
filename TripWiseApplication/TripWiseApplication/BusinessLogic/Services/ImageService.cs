using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.Services;

public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;

    public ImageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public IEnumerable<Image> GetAll()
    {
        return _unitOfWork.ImageRepository.GetAll();
    }
}
