using HastaneOtomasyonu.Models;

namespace HastaneOtomasyon.Models
{
    public interface IKullanici
    {
        Guid Id { get; set; }
        string Ad { get; set; }
        string Soyad { get; set; }

        string Email { get; set; }
        string Sifre { get; set; }
        Status Status { get; set; }
    }
}
