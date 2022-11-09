using HastaneOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Controllers
{
    public class YoneticiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personel)
        {

            if (ModelState.IsValid)
            {
                personel.Email = $"{personel.Ad}{personel.Soyad}@bilgeadamhastane.com";
                HomeController.kullanicilar.Add(personel);

                return RedirectToAction("PersonelListele");
            }

            return View();
        }

        public IActionResult PersonelListele()
        {
            List<Personel> personeller = new List<Personel>();
            foreach (var item in HomeController.kullanicilar)
            {
                if (item is Personel && item.Status == Status.Aktif)
                {
                    personeller.Add((Personel)item);
                }
            }
            return View(personeller);
        }

        public IActionResult BilgileriGoster()
        {
            Yonetici yonetici = (Yonetici)LoginController.girisYapanKisi;

            return View(yonetici);
        }

        public IActionResult YoneticiBilgiGuncelle(Guid id)
        {
            var guncellenecekYonetici = (Yonetici)HomeController.kullanicilar.Find(i => i.Id == id);

            return View(guncellenecekYonetici);
        }

        [HttpPost]
        public IActionResult YoneticiBilgiGuncelle(Yonetici guncelYonetici)
        {
            var guncellenecekYonetici = (Personel)HomeController.kullanicilar.Find(i => i.Id == guncelYonetici.Id);
            if (ModelState.IsValid)
            {
                HomeController.kullanicilar.Remove(guncellenecekYonetici);
                HomeController.kullanicilar.Add(guncelYonetici);
                return RedirectToAction("BilgileriGoster");
            }

            return View(guncelYonetici);

        }
    }

}
