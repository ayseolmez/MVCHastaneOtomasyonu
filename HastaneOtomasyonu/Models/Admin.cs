using HastaneOtomasyonu.Models;

namespace HastaneOtomasyon.Models
{
    public class Admin : IKullanici
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public Status Status { get; set; } = Status.Aktif;
    }
}
