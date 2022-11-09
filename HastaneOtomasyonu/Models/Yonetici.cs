using HastaneOtomasyonu.Models;

namespace HastaneOtomasyon.Models
{
    public class Yonetici : IKullanici, ICalisan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string? Email { get; set; }
        public string Sifre { get; set; }

        private string tcno { get; set; }
        public string? TcNo { get; set; }
        private decimal _Maas { get; set; }
        public decimal Maas
        {
            get { return _Maas; }
            set
            {
                if (value < 0 || value < 5500)
                {
                    _Maas = 5500;
                }
                else
                    _Maas = value;
            }
        }

        public Status Status { get; set; } = Status.Aktif;
    }
}
