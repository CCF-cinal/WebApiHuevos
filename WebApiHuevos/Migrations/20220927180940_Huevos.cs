using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiHuevos.Migrations
{
    public partial class Huevos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huevos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncargadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huevos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huevos_Encargados_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Encargados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huevos_EncargadoId",
                table: "Huevos",
                column: "EncargadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huevos");
        }
    }
}
