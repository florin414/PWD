using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;

public interface ICustomerService
{
    void Login(string email, string password);
    void Logout(int id);
    void Register(Customer customer);
}
