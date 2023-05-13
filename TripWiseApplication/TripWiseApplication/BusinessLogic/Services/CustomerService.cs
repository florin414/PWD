//using TripWiseApplication.BusinessLogic.IServices;
//using TripWiseApplication.DataAccess.Repositories.Interfaces;
//using TripWiseApplication.Models;

//namespace TripWiseApplication.BusinessLogic.Services;

//public class CustomerService : ICustomerService
//{
//    private readonly IUnitOfWork _unitOfWork;

//    public CustomerService(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
//    }

//    public void Login(string email, string password)
//    {
//        var searchUser = _unitOfWork.CustomerRepository.GetByFilter( cutomer => cutomer.Email == email ).ToList();
//        var user = searchUser.FirstOrDefault( customer => customer.Password == password);

//        if (user != null) 
//        {
//            user.IsUserAuthenticated = true;
//            _unitOfWork.CustomerRepository.Update(user);
//            _unitOfWork.Save();
//        }
       
//    }

//    public async void Logout(int id)
//    {
//       var user = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
//       if (user != null) 
//       {
//            user.IsUserAuthenticated = false;
//            _unitOfWork.CustomerRepository.Update(user);
//            _unitOfWork.Save();
//       }
//    }

//    public async void Register(Customer customer) 
//    {
//        await _unitOfWork.CustomerRepository.AddAsync(customer);
//        _unitOfWork.Save();
//    }
//}
