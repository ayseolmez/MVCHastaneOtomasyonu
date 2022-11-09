namespace HastaneOtomasyon.Models
{
    public class PersonelYoneticiVM
    {
        public List<Personel> Personeller { get; set; }
        public List<Yonetici> Yoneticiler { get; set; }

        public PersonelYoneticiVM()
        {
            Personeller = new List<Personel>();
            Yoneticiler = new List<Yonetici>();
        }
    }
}
