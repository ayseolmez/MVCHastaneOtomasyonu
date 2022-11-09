using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models;
using System.Diagnostics;
using HastaneOtomasyonu.Models;

namespace HastaneOtomasyon.Controllers
{

    public class HomeController : Controller
    {
        public static List<IKullanici> kullanicilar = new List<IKullanici>()
         {
        new Admin(){Ad="Şahin", Soyad="Uzun",Email="sahinuzun03@gmail.com", Sifre="12345"},
        new Personel(){Ad="Ayşe", Soyad="Ölmez",Email="ayseolmez@gmail.com", Sifre="12345"}
         };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}