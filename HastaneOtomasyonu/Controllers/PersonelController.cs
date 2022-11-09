using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models;

namespace HastaneOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BilgileriGoster()
        {
            Personel personel = (Personel)LoginController.girisYapanKisi;

            return View(personel);
        }
        public IActionResult PersonelBilgiGuncelle(Guid id)
        {
            var guncellenecekPersonel = (Personel)HomeController.kullanicilar.Find(i => i.Id == id);

            return View(guncellenecekPersonel);
        }

        [HttpPost]
        public IActionResult PersonelBilgiGuncelle(Personel guncelPersonel)
        {
            var guncellenecekPersonel = (Personel)HomeController.kullanicilar.Find(i => i.Id == guncelPersonel.Id);
            if (ModelState.IsValid)
            {
                HomeController.kullanicilar.Remove(guncellenecekPersonel);
                HomeController.kullanicilar.Add(guncelPersonel);
                return RedirectToAction("BilgileriGoster");
            }

            return View(guncelPersonel);

        }

        public IActionResult ArkadasListele()
        {
            //istersek burada homecontrollerde listeyi dönüp liste içerisindeki yöneticileri bir listeye atabiliriz.
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
    }
}
