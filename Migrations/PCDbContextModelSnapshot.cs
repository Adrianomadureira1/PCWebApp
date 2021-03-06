// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PCWebApp.Repository;

namespace PCWebApp.Migrations
{
    [DbContext(typeof(PCDbContext))]
    partial class PCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ColaboradorDepartamento", b =>
                {
                    b.Property<Guid>("ColaboradoresID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartamentosID")
                        .HasColumnType("uuid");

                    b.HasKey("ColaboradoresID", "DepartamentosID");

                    b.HasIndex("DepartamentosID");

                    b.ToTable("ColaboradorDepartamento");
                });

            modelBuilder.Entity("ColaboradorGrupo", b =>
                {
                    b.Property<Guid>("ColaboradoresID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GruposID")
                        .HasColumnType("uuid");

                    b.HasKey("ColaboradoresID", "GruposID");

                    b.HasIndex("GruposID");

                    b.ToTable("ColaboradorGrupo");
                });

            modelBuilder.Entity("PCWebApp.Repository.Entity.Colaborador", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("PRS")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("PCWebApp.Repository.Entity.Departamento", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            ID = new Guid("3a3f882d-f021-44e0-86eb-6f4b41b1490e"),
                            Nome = "FINANCEIRO"
                        },
                        new
                        {
                            ID = new Guid("48a7ef00-e0d3-4969-a053-22577972cf4b"),
                            Nome = "ADMINISTRAÇÃO"
                        },
                        new
                        {
                            ID = new Guid("620382d5-8741-480e-bffc-91d54f165888"),
                            Nome = "DIREÇÃO"
                        },
                        new
                        {
                            ID = new Guid("879db90c-4ef3-4d30-9a34-af19c91faec7"),
                            Nome = "OPERACIONAL"
                        },
                        new
                        {
                            ID = new Guid("f4258638-cfe7-4f97-a10f-cb448381f317"),
                            Nome = "INFRAESTRUTURA"
                        },
                        new
                        {
                            ID = new Guid("364b1834-ba9e-44dc-9e5a-abcc6f7dc99e"),
                            Nome = "DESENVOLVIMENTO"
                        },
                        new
                        {
                            ID = new Guid("b2681150-0960-47ef-b83e-08a335558de9"),
                            Nome = "COMERCIAL"
                        });
                });

            modelBuilder.Entity("PCWebApp.Repository.Entity.Grupo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Grupos");

                    b.HasData(
                        new
                        {
                            ID = new Guid("4052f5fd-1d9a-4d19-9dc8-159632b3005c"),
                            Nome = "CLT"
                        },
                        new
                        {
                            ID = new Guid("542a8c4a-fa3d-4cfa-9e26-84c9f55ac679"),
                            Nome = "PJ"
                        },
                        new
                        {
                            ID = new Guid("1e732133-6bac-4967-96e0-346d34708a78"),
                            Nome = "Freelancer"
                        },
                        new
                        {
                            ID = new Guid("5da526ec-5cda-4450-a379-fbd58741d529"),
                            Nome = "Parceiros"
                        },
                        new
                        {
                            ID = new Guid("19b20af0-12a8-4c6b-84fc-e97262fda449"),
                            Nome = "Outros"
                        });
                });

            modelBuilder.Entity("ColaboradorDepartamento", b =>
                {
                    b.HasOne("PCWebApp.Repository.Entity.Colaborador", null)
                        .WithMany()
                        .HasForeignKey("ColaboradoresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCWebApp.Repository.Entity.Departamento", null)
                        .WithMany()
                        .HasForeignKey("DepartamentosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ColaboradorGrupo", b =>
                {
                    b.HasOne("PCWebApp.Repository.Entity.Colaborador", null)
                        .WithMany()
                        .HasForeignKey("ColaboradoresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCWebApp.Repository.Entity.Grupo", null)
                        .WithMany()
                        .HasForeignKey("GruposID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
