using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using TripWiseApplication.Areas.Identity.Pages.Account;
namespace TripWiseApplication.BusinessLogic.Services;

public class UserAuthentificationService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IEmailSender _emailSender;

    public UserAuthentificationService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IUserStore<IdentityUser> userStore,
        IUserEmailStore<IdentityUser> emailStore,
        ILogger<RegisterModel> logger,
        IEmailSender emailSender
    )
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
        _emailStore = emailStore ?? throw new ArgumentNullException(nameof(emailStore));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
    }

    public void Register() 
    {

    }

    //public async void CreateUser(IdentityUser user, InputModel Input)
    //{
    //    await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
    //    await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
    //    var result = await _userManager.CreateAsync(user, Input.Password);
    //}

    public void Login() { }
}
