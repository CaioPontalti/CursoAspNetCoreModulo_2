using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace ConsoleAppEntityFramework
{
    public class ApplicationDbContext : DbContext
    {

        //Metodo criado para quando for excluir um estudante, ao inves de excluir, ele altera a coluna EstaExcluido para true
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries<Estudante>()
                                              .Where(e => e.State == EntityState.Deleted && 
                                                     e.Metadata.GetProperties().Any(n => n.Name == "EstaExcluido")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaExcluido"] = true;
            }

            return base.SaveChanges();  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cria a chave da tabela EstudanteCurso composta com as duas colunas.
            modelBuilder.Entity<EstudanteCurso>().HasKey(c => new { c.CursoId, c.EstudanteId });

            //Cria um filtro (where) para uma tabela. Sempre que fizer uma consuta ele já utiliza esse Where
            modelBuilder.Entity<EstudanteCurso>().HasQueryFilter(e => e.Ativo == true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=STFSAOC042966-L\SQLEXPRESS; Initial Catalog=BancoApp;Integrated Security=True") // ;
             
                //As configurações abaixo são opcionais. Servem para gerar log do Entity Framework no console.
                          .EnableSensitiveDataLogging(true)
                          .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && 
                                                                            category == DbLoggerCategory.Database.Command.Name, true));
        }


        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudanteCurso> EstudantesCursos { get; set; }
        

    }
}
