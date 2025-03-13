using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Models;



namespace ProjetoEscola.Data
{
    public class EscolaDBContext : DbContext
    {
        public EscolaDBContext(DbContextOptions<EscolaDBContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Notas> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir o nome correto das tabelas
            modelBuilder.Entity<Aluno>().ToTable("tbAluno");
            modelBuilder.Entity<Disciplina>().ToTable("tbDisciplina");
            modelBuilder.Entity<Professor>().ToTable("tbProfessor");
            modelBuilder.Entity<Notas>().ToTable("tbNotas");
            

            // Definição das chaves primárias
            modelBuilder.Entity<Aluno>().HasKey(a => a.idAluno);
            modelBuilder.Entity<Disciplina>().HasKey(d => d.idDis);
            modelBuilder.Entity<Professor>().HasKey(p => p.IdProfessor);
            modelBuilder.Entity<Notas>().HasKey(n => n.IdNota);

            // Relacionamento Livro -> Genero (1:N)
            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Professor)
                .WithMany(n => n.NotaProfessor)
                .HasForeignKey(n => n.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Aluno)
                .WithMany(n => n.NotaAluno)
                .HasForeignKey(n => n.IdAluno)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notas>()
                .HasOne(n => n.Disciplina)
                .WithMany(n => n.NotaDisciplina)
                .HasForeignKey(n => n.IdDisciplina)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
