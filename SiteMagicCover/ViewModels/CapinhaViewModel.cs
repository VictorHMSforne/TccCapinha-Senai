using System.ComponentModel.DataAnnotations;

namespace SiteMagicCover.ViewModels
{
    public class CapinhaViewModel
    {
        [Required(ErrorMessage = "A marca deve ser informada")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O modelo deve ser informado")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O nome do celular deve ser informado")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string NomeCelular { get; set; }

        [Required(ErrorMessage = "O preço deve ser informado")]
        public double Preco { get; set; }

        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemUrl { get; set; }

        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemThumbUrl { get; set; }

        public bool Disponibilidade { get; set; }

        public bool IsPersonalizada { get; set; }

        public int CapinhaId { get; set; }

        public int CategoriaId { get; set; }
    }
}
