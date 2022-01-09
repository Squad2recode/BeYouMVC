using Microsoft.EntityFrameworkCore;

namespace BeYou.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<cadastroParceiros> CadastroParceiros { get; set; }
        public DbSet<cadastroVagasEmprego> CadastroVagasEmprego { get; set; }
        public DbSet<cadastroVoluntarios> CadastroVoluntarios { get; set; }
        public DbSet<casasAcolhimento> casasAcolhimentos { get; set; }
        public DbSet<cadastroCursos> CadastroCursos { get; set; }
    }
}
