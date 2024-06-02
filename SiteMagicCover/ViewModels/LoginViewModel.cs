using System.ComponentModel.DataAnnotations;

namespace SiteMagicCover.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } // essa prop tem o objetivo de voltar para onde o usuário estava
 
    }
}
