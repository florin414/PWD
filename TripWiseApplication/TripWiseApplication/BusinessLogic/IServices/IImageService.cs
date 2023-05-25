using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;
public interface IImageService
{
    IEnumerable<Image> GetAll();
}