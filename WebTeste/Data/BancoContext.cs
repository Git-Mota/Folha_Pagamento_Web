using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebTeste.Models;

namespace WebTeste.Data
{
    public class BancoContext : DbContext 
    {
        public BancoContext(DbContextOptions<BancoContext> options): base (options)
        {

        }

        public DbSet<FeriasModel> Tab_Ferias { get; set; }
        public DbSet<DadosFuncionarioEFeriasModel> Tab_Funcionario_Ferias { get;set; }
        public DbSet<PontoModel> Tab_Ponto { get; set; }
        public DbSet<UsuarioModel> Tab_Usuario { get; set; }
        public DbSet<FuncionarioModel> Tab_Funcionario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(usr => usr.Funcionario)
                .WithMany()
                .HasForeignKey(usr => usr.db_Id_Funcionario);
        }

    }
}
