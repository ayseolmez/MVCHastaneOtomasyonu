using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models;

namespace HastaneOtomasyon.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YoneticiEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YoneticiEkle(Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                yonetici.Email = $"{yonetici.Ad}{yonetici.Soyad}@bilgeadamhastane.com";
                //Eğer model doğruysa yöneticiyi listeye ekle
                HomeController.kullanicilar.Add(yonetici);

                //YoneticileriListele sayfasına yönlendiriyoruz.
                return RedirectToAction("YoneticileriListeleController");
            }

            return View();
        }

        public IActionResult YoneticileriListeleController()
        {
            //istersek burada homecontrollerde listeyi dönüp liste içerisindeki yöneticileri bir listeye atabiliriz.
            List<Yonetici> yoneticler = new List<Yonetici>();
            foreach (var item in HomeController.kullanicilar)
            {
                if (item is Yonetici && item.Status == Status.Aktif)
                {
                    yoneticler.Add((Yonetici)item);
                }
            }
            return View(yoneticler);
        }

        public IActionResult YoneticileriListeleView()
        {

            //Ya da HomeController'dan kullacıları listeye gönderip
            //Görüntülecek kişilerin kim olacağını gidip view tarafında yazacağız.
            return View(HomeController.kullanicilar);
        }

        public IActionResult BilgileriGoster()
        {
            Admin admin = (Admin)LoginController.girisYapanKisi;
            return View(admin);
        }

        public IActionResult YoneticiGuncelle(Guid id)
        {
            var guncellenecekYonetici = (Yonetici)HomeController.kullanicilar.Find(i => i.Id == id);

            return View(guncellenecekYonetici);
        }

        [HttpPost]
        public IActionResult YoneticiGuncelle(Yonetici guncelYonetici)
        {
            var guncellenecekYonetici = (Yonetici)HomeController.kullanicilar.Find(i => i.Id == guncelYonetici.Id);
            if (ModelState.IsValid)
            {
                HomeController.kullanicilar.Remove(guncellenecekYonetici);
                HomeController.kullanicilar.Add(guncelYonetici);
                return RedirectToAction("YoneticileriListeleController");
            }

            return View(guncelYonetici);

        }
        public static IKullanici silinecekYonetici;
        public static IKullanici girisYapanKullanici;

        public IActionResult YoneticiSil(Guid id)
        {
            silinecekYonetici = (Yonetici)HomeController.kullanicilar.Find(i => i.Id == id);
            return View(silinecekYonetici);
        }
        [HttpPost]
        public IActionResult YoneticiSil(Yonetici yonetici)
        {
            silinecekYonetici = (Yonetici)HomeController.kullanicilar.Find(i => i.Id == yonetici.Id);
            silinecekYonetici.Status = Status.Pasif;


            return RedirectToAction("YoneticileriListeleController");
        }

        public IActionResult PersonelListele()
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
                //Eğer model doğruysa yöneticiyi listeye ekle
                HomeController.kullanicilar.Add(personel);

                //YoneticileriListele sayfasına yönlendiriyoruz.
                return RedirectToAction("PersonelListele");
            }

            return View();
        }

        public IActionResult PersonelYoneticiListele()
        {

            PersonelYoneticiVM model = new PersonelYoneticiVM();

            foreach (var item in HomeController.kullanicilar)
            {
                if (item is Yonetici)
                {
                    model.Yoneticiler.Add((Yonetici)item);
                }
                if (item is Personel)
                {
                    model.Personeller.Add((Personel)item);
                }
            }
            return View(model);

        }


    }

}
