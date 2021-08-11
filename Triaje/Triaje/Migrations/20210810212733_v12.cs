using Microsoft.EntityFrameworkCore.Migrations;

namespace Triaje.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TriajeNs",
                columns: table => new
                {
                    IdConsultaN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tuberculosis = table.Column<bool>(type: "bit", nullable: false),
                    Gripe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriajeNs", x => x.IdConsultaN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TriajeNs");
        }
    }
}
