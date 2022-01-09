using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeYou.Migrations
{
    public partial class banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cadastroCursos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_instituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade_UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    turno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastroCursos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadastroParceiros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_parceiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mensagem_parceiro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastroParceiros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadastroVagasEmprego",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade_UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beneficios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastroVagasEmprego", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadastroVoluntarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_voluntario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mensagem_voluntario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastroVoluntarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "casasAcolhimento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_casa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_casasAcolhimento", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadastroCursos");

            migrationBuilder.DropTable(
                name: "cadastroParceiros");

            migrationBuilder.DropTable(
                name: "cadastroVagasEmprego");

            migrationBuilder.DropTable(
                name: "cadastroVoluntarios");

            migrationBuilder.DropTable(
                name: "casasAcolhimento");
        }
    }
}
