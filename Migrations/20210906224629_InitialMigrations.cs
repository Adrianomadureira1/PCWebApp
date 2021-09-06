using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWebApp.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    PRS = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorDepartamento",
                columns: table => new
                {
                    ColaboradoresID = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartamentosID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorDepartamento", x => new { x.ColaboradoresID, x.DepartamentosID });
                    table.ForeignKey(
                        name: "FK_ColaboradorDepartamento_Colaboradores_ColaboradoresID",
                        column: x => x.ColaboradoresID,
                        principalTable: "Colaboradores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradorDepartamento_Departamentos_DepartamentosID",
                        column: x => x.DepartamentosID,
                        principalTable: "Departamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorGrupo",
                columns: table => new
                {
                    ColaboradoresID = table.Column<Guid>(type: "uuid", nullable: false),
                    GruposID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorGrupo", x => new { x.ColaboradoresID, x.GruposID });
                    table.ForeignKey(
                        name: "FK_ColaboradorGrupo_Colaboradores_ColaboradoresID",
                        column: x => x.ColaboradoresID,
                        principalTable: "Colaboradores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradorGrupo_Grupos_GruposID",
                        column: x => x.GruposID,
                        principalTable: "Grupos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "ID", "Nome" },
                values: new object[,]
                {
                    { new Guid("3a3f882d-f021-44e0-86eb-6f4b41b1490e"), "FINANCEIRO" },
                    { new Guid("48a7ef00-e0d3-4969-a053-22577972cf4b"), "ADMINISTRAÇÃO" },
                    { new Guid("620382d5-8741-480e-bffc-91d54f165888"), "DIREÇÃO" },
                    { new Guid("879db90c-4ef3-4d30-9a34-af19c91faec7"), "OPERACIONAL" },
                    { new Guid("f4258638-cfe7-4f97-a10f-cb448381f317"), "INFRAESTRUTURA" },
                    { new Guid("364b1834-ba9e-44dc-9e5a-abcc6f7dc99e"), "DESENVOLVIMENTO" },
                    { new Guid("b2681150-0960-47ef-b83e-08a335558de9"), "COMERCIAL" }
                });

            migrationBuilder.InsertData(
                table: "Grupos",
                columns: new[] { "ID", "Nome" },
                values: new object[,]
                {
                    { new Guid("4052f5fd-1d9a-4d19-9dc8-159632b3005c"), "CLT" },
                    { new Guid("542a8c4a-fa3d-4cfa-9e26-84c9f55ac679"), "PJ" },
                    { new Guid("1e732133-6bac-4967-96e0-346d34708a78"), "Freelancer" },
                    { new Guid("5da526ec-5cda-4450-a379-fbd58741d529"), "Parceiros" },
                    { new Guid("19b20af0-12a8-4c6b-84fc-e97262fda449"), "Outros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorDepartamento_DepartamentosID",
                table: "ColaboradorDepartamento",
                column: "DepartamentosID");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorGrupo_GruposID",
                table: "ColaboradorGrupo",
                column: "GruposID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorDepartamento");

            migrationBuilder.DropTable(
                name: "ColaboradorGrupo");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Grupos");
        }
    }
}
