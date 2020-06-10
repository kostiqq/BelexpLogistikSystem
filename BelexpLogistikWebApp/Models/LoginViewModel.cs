using System.ComponentModel.DataAnnotations;

namespace BelexpLogistikWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "Имя пользователя")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
