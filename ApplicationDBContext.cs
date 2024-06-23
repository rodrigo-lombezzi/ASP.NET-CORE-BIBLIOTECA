using biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace biblioteca
{
	public class ApplicationDBContext:DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}

		public DbSet<EmprestimoModels> Emprestimos { get; set; }
	}
}
