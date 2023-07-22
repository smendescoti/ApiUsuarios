using ApiUsuarios.Domain.Models;
using ApiUsuarios.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de configuração para o EntityFramework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método que define o banco de dados acessado pelo EntityFramework
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDApiUsuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer("Data Source=tcp:bdaulascoti.database.windows.net,1433;Initial Catalog=bdusuariosapi;User ID=usercoti;Password=Coti2023");
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        /// <summary>
        /// Propriedade para fornecer os métodos do repositório
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
