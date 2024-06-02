using System.ComponentModel.DataAnnotations;

namespace SiteMagicCover.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

    }
}
