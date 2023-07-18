using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PersonelLoginMCVPoject.Data.Entities
{
    public class Personel
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Yas { get; set; }
        public string? Cinsiyet { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Adres { get; set; }
    }
}
