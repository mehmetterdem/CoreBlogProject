using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password",ErrorMessage = "Şifre Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }
    }
}
