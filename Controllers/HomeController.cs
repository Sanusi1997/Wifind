using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WiFind.Entities;
using WiFind.Models;
using WiFind.Services.Interfaces;

namespace WiFind.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly IWiFindUserService _wiFindUserService;
    public HomeController(ILogger<HomeController> logger, IWiFindUserService wiFindUserService)
    {
        _logger = logger;
        _wiFindUserService = wiFindUserService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult BuyerLogin()
    {

        return View();
    }
    public IActionResult BuyerRegister()
    {

        return View();
    }
    public IActionResult SellerRegister()
    {

        return View();
    }
    public IActionResult SellerLogin()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterBuyer(AuthenticationModel userInput)
    {

        var userInRepo = await _wiFindUserService.GetUserByEmail(userInput.Email);

        if (userInRepo != null)
        {
            ViewBag.BuyerRegistrationError = "Account with Email already Exists";
            return View("BuyerRegister");
        }
        var userEntity = new WiFindUser();
        userEntity.Email = userInput.Email;
        userEntity.Password = userInput.Password;
        userEntity.UserType = "Buyer";
        try
        {

            _wiFindUserService.AddUser(userEntity);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message.ToString());
        }

        ViewBag.BuyerSuccessfulRegistration = "Successfully Created Buyer Account";
        return View("BuyerLogin");
    }
    [HttpPost]
    public async Task<IActionResult> RegisterSeller(AuthenticationModel userInput)
    {

        var userInRepo = await _wiFindUserService.GetUserByEmail(userInput.Email);

        if (userInRepo != null)
        {
            ViewBag.SellerRegistrationError = "Account with Email already Exists";
            return View("SellerRegister");
        }
        var userEntity = new WiFindUser();
        userEntity.Email = userInput.Email;
        userEntity.Password = userInput.Password;
        userEntity.UserType = "Seller";
        try
        {

            _wiFindUserService.AddUser(userEntity);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message.ToString());
        }

        ViewBag.SellerSuccessfulRegistration = "Successfully Created Seller Account";
        return View("SellerLogin");
    }


    [HttpPost]
    public async Task<IActionResult> LoginBuyer(LoginModel userInput)
    {

        var userInRepo = await _wiFindUserService.AuthenticateUser(userInput.Email, userInput.Password);

        if (userInRepo == null)
        {
            ViewBag.BuyerLoginError = "Password or Email is incorrect";
            return View("BuyerLogin");
        }
        else
        {
            if (userInRepo.UserType != "Buyer")
            {
                ViewBag.BuyerLoginError = "Not a Buyer! Return to seller login instead.";
                return View("BuyerLogin");
            }
            else
            {

                var userDto = new UserDTO();
                userDto.WifiUserId = userInRepo.WiFindUserId.ToString();
                return RedirectToAction("BuyerDashboard", "Dashboard", userDto);
            }
        }
    }
    [HttpPost]
    public async Task<IActionResult> LoginSeller(LoginModel userInput)
    {

        var userInRepo = await _wiFindUserService.AuthenticateUser(userInput.Email, userInput.Password);

        if (userInRepo == null)
        {
            ViewBag.SellerLoginError = "Password or Email is incorrect";
            return View("SellerLogin");
        }
        else
        {
            if (userInRepo.UserType != "Seller")
            {
                ViewBag.SellerLoginError = "Not a Seller! Return to buyer login instead.";
                return View("SellerLogin");
            }
            else
            {
                var userDto = new UserDTO();
                userDto.WifiUserId = userInRepo.WiFindUserId.ToString();
                return RedirectToAction("SellerDashboard", "Dashboard", userDto);

            }
        }
    }

}

