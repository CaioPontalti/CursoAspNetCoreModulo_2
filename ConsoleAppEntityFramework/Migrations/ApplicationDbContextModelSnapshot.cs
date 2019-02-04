﻿// <auto-generated />
using ConsoleAppEntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleAppEntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleAppEntityFramework.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstudanteId");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.HasIndex("EstudanteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.Estudante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaExcluido");

                    b.Property<int>("Idade");

                    b.Property<string>("Nome");

                    b.Property<int>("TurmaId");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Estudantes");
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.EstudanteCurso", b =>
                {
                    b.Property<int>("CursoId");

                    b.Property<int>("EstudanteId");

                    b.Property<bool>("Ativo");

                    b.HasKey("CursoId", "EstudanteId");

                    b.HasIndex("EstudanteId");

                    b.ToTable("EstudantesCursos");
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.Endereco", b =>
                {
                    b.HasOne("ConsoleAppEntityFramework.Estudante")
                        .WithOne("Endereco")
                        .HasForeignKey("ConsoleAppEntityFramework.Endereco", "EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.Estudante", b =>
                {
                    b.HasOne("ConsoleAppEntityFramework.Turma")
                        .WithMany("Estudantes")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleAppEntityFramework.EstudanteCurso", b =>
                {
                    b.HasOne("ConsoleAppEntityFramework.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConsoleAppEntityFramework.Estudante", "Estudante")
                        .WithMany()
                        .HasForeignKey("EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
