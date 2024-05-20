using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(100,ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da Categoria")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }
        [StringLength(150, ErrorMessage = "O tamanho máximo é 150 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da Categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Capinha> Capinha { get; set; }  // quando coloco em List, fica uma relação de 1 para muitos, ou seja, 
        //1 Categoria pode ter muitas capinhas, mas uma capinha so pode ter uma categoria
    }
}
