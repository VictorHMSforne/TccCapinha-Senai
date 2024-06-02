using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMagicCover.Models
{
    [Table("Capinhas")]
    public class Capinha
    {
        [Key]
        public int CapinhaId { get; set; }

        [Required(ErrorMessage = "O nome da Marca deve ser informado")]
        [Display(Name = "Marca Do Celular")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O nome do Modelo deve ser informado")]
        [Display(Name = "Modelo Do Celular")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O nome do Celular deve ser informado")]
        [Display(Name = "Nome Do Celular")]
        [StringLength(80, ErrorMessage = "Deve ter no máximo 80 caracteres")]
        public string NomeCelular { get; set; }

        [Required(ErrorMessage = "O Preço deve ser informado")]
        [Display(Name = "Preço Celular")]
        public double Preco { get; set; }  //mudei aqui

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "Deve ter no máximo 200 caracteres")]
        public string ImagemThumbUrl  { get; set; }

        

        [Display(Name = "Disponível ?")]
        public bool Disponibilidade { get; set; }

        public int CategoriaId { get; set; } //Uma FK
        public virtual Categoria Categoria { get; set; }//propriedade de Navegação. Aqui ele define o relacionamento com a tabela Capinha

    }
}
