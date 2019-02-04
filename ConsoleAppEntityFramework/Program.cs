using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inserir();
            //Consultar();
            //ConsultarWhere();
            //Deletar();
            DeletarComState();
            //Editar();
            //EditarComState();
            //InserirDadosRelacionados();
            //InserirEnderecoParaUmEstudante();
            //ListarEstudantesEnderecos_Include();
            //ConsultarTurmaDadosRelacionados();
            //InsertMuitosParaMuitos();
            //ConsultaMuitosParaMuitos();

        }

        static void Inserir()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = new Estudante() { Nome = "Douglas Souza" };
                context.Estudantes.Add(estudante);
                context.SaveChanges();
            }
        }

        static void Consultar()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudantes = context.Estudantes.ToList();

            }
        }

        static void ConsultarWhere()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudantes = context.Estudantes.Where(e => e.Nome == "Caio Pontalti").ToList();

            }
        }

        static void Deletar()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = context.Estudantes.Where(e => e.Nome == "Douglas Souza").FirstOrDefault();
                context.Estudantes.Remove(estudante);
                context.SaveChanges();
            }
        }

        static void DeletarComState()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = context.Estudantes.Where(e => e.Nome == "CAIO").FirstOrDefault();
                context.Entry(estudante).State = EntityState.Deleted; //Microsoft.EntityFrameworkCore;
                context.SaveChanges();
            }
        }

        static void Editar()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = context.Estudantes.Where(e => e.Nome == "Teste Add").FirstOrDefault();
                estudante.Nome = "Teste Alterado Editar";
                context.Estudantes.Update(estudante);
                context.SaveChanges();
            }
        }

        static void EditarComState()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = context.Estudantes.Where(e => e.Nome == "Teste Alterado Editar").FirstOrDefault();
                estudante.Nome = "Teste Alterado comState";
                context.Entry(estudante).State = EntityState.Modified; //Microsoft.EntityFrameworkCore;
                context.SaveChanges();
            }

        }   
        static void InserirDadosRelacionados()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = new Estudante() { Nome = "Caio", Idade = 20};

                var endereco = new Endereco();
                endereco.Rua = "Rua B";
                estudante.Endereco = endereco;

                context.Estudantes.Add(estudante);

                context.SaveChanges();
            }
        }

        static void InserirEnderecoParaUmEstudante()//relacionamento Um para Um
        {
            using (var context = new ApplicationDbContext())
            {
                var estudanteEnd = new Estudante();
                estudanteEnd.Id = 3;

                var enderecoNovo = new Endereco();
                enderecoNovo.Rua = "Rua C";
                enderecoNovo.EstudanteId = estudanteEnd.Id;

                context.Enderecos.Add(enderecoNovo);
                context.SaveChanges();
            }
        }

        static void ListarEstudantesEnderecos_Include()
        {
            using (var context = new ApplicationDbContext())
            {
                var lstEstudantes = context.Estudantes.Include(e => e.Endereco).ToList();
            }
        }
        
        static void ConsultarTurmaDadosRelacionados()
        {
            using (var context = new ApplicationDbContext())
            {
                var lista = context.Turmas.Where(t => t.Id == 1).Include(e => e.Estudantes).ToList();
            } 
        }

        static void InsertMuitosParaMuitos()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudate = context.Estudantes.FirstOrDefault();
                var curso = context.Cursos.FirstOrDefault();

                var ec = new EstudanteCurso();
                ec.CursoId = curso.Id;
                ec.EstudanteId = estudate.Id;
                ec.Ativo = true;

                context.Entry(ec).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        static void ConsultaMuitosParaMuitos()
        {
            using (var context = new ApplicationDbContext())
            {
                var est = context.EstudantesCursos.Where(e => e.EstudanteId == 3)
                                                  .Include(e => e.Estudante.Endereco)
                                                  .Include(e => e.Curso).ToList();

            }

        }
    }
}
