using System.ComponentModel.DataAnnotations;

namespace biblioteca.Models
{
	public class EmprestimoModels
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Digite o campo recebedor")]
		public string Recebedor { get; set; }
        [Required(ErrorMessage = "Digite o campo fornecedor")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do livro")]
        public string LivroEmprestado { get; set; }
		public DateTime RecebedorData { get; set; } = DateTime.Now; //data atual

	}
}
