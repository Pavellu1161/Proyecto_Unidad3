using Microsoft.EntityFrameworkCore.Migrations;

namespace Triaje.Migrations
{
    public partial class SegundaMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obstetricas",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paro_Cardiorespiratorio = table.Column<bool>(type: "bit", nullable: false),
                    Crisis_Convulsiva = table.Column<bool>(type: "bit", nullable: false),
                    Dolor_CSD = table.Column<bool>(type: "bit", nullable: false),
                    Movimientos_Fetales = table.Column<bool>(type: "bit", nullable: false),
                    sistolica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diastolica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saturacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frecuencia_Cardiaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperatura_Axilar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frecuencia_Respiratoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentidadPaciente = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    IdentidadPersonal = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obstetricas", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Obstetricas_Pacientes_IdentidadPaciente",
                        column: x => x.IdentidadPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdentidadPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obstetricas_Personals_IdentidadPersonal",
                        column: x => x.IdentidadPersonal,
                        principalTable: "Personals",
                        principalColumn: "IdentidadPersonal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obstetricas_IdentidadPaciente",
                table: "Obstetricas",
                column: "IdentidadPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Obstetricas_IdentidadPersonal",
                table: "Obstetricas",
                column: "IdentidadPersonal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obstetricas");
        }
    }
}
