using Microsoft.EntityFrameworkCore;
using PCWebApp.Repository.Entity;
using System;

namespace PCWebApp.Repository
{
    public class PCDbContext: DbContext
    {
        public PCDbContext(DbContextOptions<PCDbContext> options): base(options){ }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Colaborador>()
            .HasMany(t => t.Departamentos)
            .WithMany(t => t.Colaboradores)
            .UsingEntity(j => j.ToTable("ColaboradorDepartamento"));

            modelBuilder.Entity<Grupo>()
            .HasData(
            new Grupo { ID = Guid.NewGuid(), Nome = "CLT" },
            new Grupo { ID = Guid.NewGuid(), Nome = "PJ" },
            new Grupo { ID = Guid.NewGuid(), Nome = "Freelancer" },
            new Grupo { ID = Guid.NewGuid(), Nome = "Parceiros" },
            new Grupo { ID = Guid.NewGuid(), Nome = "Outros" });

            modelBuilder.Entity<Departamento>()
            .HasData(
            new Departamento { ID = Guid.NewGuid(), Nome = "FINANCEIRO" },
            new Departamento { ID = Guid.NewGuid(), Nome = "ADMINISTRAÇÃO" },
            new Departamento { ID = Guid.NewGuid(), Nome = "DIREÇÃO" },
            new Departamento { ID = Guid.NewGuid(), Nome = "OPERACIONAL" },
            new Departamento { ID = Guid.NewGuid(), Nome = "INFRAESTRUTURA" },
            new Departamento { ID = Guid.NewGuid(), Nome = "DESENVOLVIMENTO" },
            new Departamento { ID = Guid.NewGuid(), Nome = "COMERCIAL" });

            base.OnModelCreating(modelBuilder);
        }
    }
}