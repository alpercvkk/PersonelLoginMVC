using System.ComponentModel.DataAnnotations;

namespace PersonelLoginMCVPoject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="UserName alanı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Parola alanı boş geçilemez")]
        [MinLength(8,ErrorMessage ="Parola min 8 karakter uzunluğunda olmalı")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }    
    }
}
