using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models;

namespace HastaneOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            //HttpGet --Bize sayfayı getirir.

            return View();
        }

        //Static olarak tanımlandığı için giriş yapan bilgilerine ihtiyacım olduğu zaman bu değişken değerine sınıf adından ulaşacağız.
        public static IKullanici girisYapanKisi;

        [HttpPost]
        public IActionResult Login(string emailAdress, string sifre)
        {
            girisYapanKisi = HomeController.kullanicilar.Find(i => i.Email == emailAdress && i.Sifre == sifre);

            if (girisYapanKisi is Admin)
            {
                //Burada AdminController Index'e göndereceğim
                return RedirectToAction("Index", "Admin"); //Admin controllerına gideceğini söyledik.
            }
            if (girisYapanKisi is Yonetici)
            {
                //Burada Yonetici Controller Index'e göndereceğim
                return RedirectToAction("Index", "Yonetici");

            }
            if (girisYapanKisi is Personel)
            {
                //Burada Personel Controller Index'e göndereceğim
                return RedirectToAction("Index", "Personel");

            }
            return RedirectToAction("Index", "Home"); //Aynı controller içindeysen sadce action'ın adını verip o action'a ait sayfanın gösterilmesini sağlayabilirsin. Ya da farklı controllerdaki action'ı tetiklemek istersen action adı + controlller adı verererek o controllerda 
        }
    }
}
