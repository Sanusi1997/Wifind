using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WiFind.Entities;
using WiFind.Models;
using WiFind.Models.ViewModels;
using WiFind.Services.Interfaces;
using WiFind.Services.WiFindServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiFind.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IWifiService _wifiService;
        private readonly IWiFindUserService _wifindUserService;
        private readonly IPaymentService _paymentService;
        private readonly IWifiConnectionService _wifiConnectionService;
        public DashboardController(ILogger<DashboardController> logger, IWifiService wifiService,
            IWiFindUserService wifindUserService, IPaymentService paymentService, IWifiConnectionService wifiConnectionService)
        {
            _logger = logger;
            _wifiService = wifiService;
            _wifindUserService = wifindUserService;
            _paymentService = paymentService;
            _wifiConnectionService = wifiConnectionService;
        }
        public async Task<IActionResult> SellerDashboard(UserDTO user)
        {
            var userInRepo = await _wifindUserService.GetUserById(user.WifiUserId);
            var wifiInRepo = await _wifiService.GetWifiByUserId(user.WifiUserId);
            if (wifiInRepo == null)
            {
                wifiInRepo = new Wifi();
            }
            if (userInRepo == null)
            {
                userInRepo = new WiFindUser();
            }

            var sellerDashboardVm = new SellerDashboardViewModel();
            sellerDashboardVm.user = userInRepo;
            sellerDashboardVm.wifi = wifiInRepo;

            return View("SellerDashboard", sellerDashboardVm);
        }
        public async Task<IActionResult> BuyerDashboard(UserDTO user)
        {
            var userInRepo = await _wifindUserService.GetUserById(user.WifiUserId);
            var allwifiInRepo = await _wifiService.GetWifis();
            if (allwifiInRepo == null)
            {
                allwifiInRepo = new List<Wifi>();
            }
            if (userInRepo == null)
            {
                userInRepo = new WiFindUser();
            }

            var buyerDashboardVm = new BuyerDashboardViewModel();
            buyerDashboardVm.user = userInRepo;
            buyerDashboardVm.wifi = allwifiInRepo.ToList();

            return View("BuyerDashboard", buyerDashboardVm);
        }
        [HttpPost]
        public JsonResult AddWifiDetails(Wifi form)
        {
            if (form == null)
            {
                return Json(new { success = false, message = "No details provided" });
            }
            else
            {
                _wifiService.AddWifi(form);
                return Json(new { success = true, message = "Successfully Created Wifi Connection" });
            }
        }

        [Route("Dashboard/BuyerConnectionStatus")]
        [Route("Dashboard/BuyerConnectionStatus/{wifiUserId}")]
        public async Task<IActionResult> BuyerConnectionStatus(string wifiUserId)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var connectionToDisplay = await _wifiConnectionService.GetWifiConnectionByUserId(wifiUserId);
#pragma warning restore CS8603 // Possible null reference argument.

            return View("BuyerConnectionStatus", connectionToDisplay);

        }
        [HttpGet]
        public async Task<IActionResult> PaymentPage([FromQuery] string wifiId)
        {
            var wifiEntity = await _wifiService.GetWifiById(wifiId);
            var paymentVm = new PaymentPageViewModel();
            paymentVm.wifi = wifiEntity;
            paymentVm.payment = new PaymentDTO();

            return View("PaymentPage", paymentVm);
        }

        public async Task<IActionResult> MakePayment([FromForm] PaymentDTO payment)
        {

            var paymentToStoreInRepo = new Payment();
            paymentToStoreInRepo.PaymentAmount = Double.Parse(payment.PaymentAmount);
            paymentToStoreInRepo.WifiId = payment.WifiId;
            paymentToStoreInRepo.WiFindUserId = payment.WifindUserId;

            var savedPaymentEntity = _paymentService.AddPayment(paymentToStoreInRepo);

            //get wifi Instance
            var wifiFromRepo = await _wifiService.GetWifiById(payment.WifiId.ToString());

            //update some fields for the wifiInstance
            wifiFromRepo.NoOfUsers += 1;
            wifiFromRepo.AmountEarned += Double.Parse(payment.PaymentAmount);
            wifiFromRepo.DateModified = DateTime.UtcNow;
            await _wifiService.Update(wifiFromRepo);

            //create a new connection
            var connectionEntity = new WifiConnection();
            connectionEntity.WifiId = payment.WifiId;
            connectionEntity.WiFindUserId = payment.WifindUserId;
            var connectionEntityToStoreInRepo = _wifiConnectionService.AddConnection(connectionEntity);

            //connection entity from Repo with owner
            {
#pragma warning disable CS8604 // Possible null reference argument.
                var connectionToDisplay = await _wifiConnectionService.GetWifiConnectionById(connectionEntityToStoreInRepo.WifiConnectionId.ToString());
#pragma warning restore CS8603 // Possible null reference argument.
                return View("BuyerConnectionStatus", connectionToDisplay);

            }
        }
    }
}
