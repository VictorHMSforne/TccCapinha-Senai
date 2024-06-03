using System.ComponentModel.DataAnnotations;

namespace SiteMagicCover.ViewModels
{
    public class CapinhaPersonalizadaViewModel
    {
        public int ClienteId { get; set; } // VERIFICAR DPS

        [Required(ErrorMessage = "Informe a Marca do Celular")]
        [StringLength(80)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Informe o Modelo do Celular")]
        [StringLength(80)]
        public string Modelo { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200)]
        public IFormFile ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200)]
        public string ImagemMockup { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200)]
        public string ImagemFinal { get; set; }
    }
}
