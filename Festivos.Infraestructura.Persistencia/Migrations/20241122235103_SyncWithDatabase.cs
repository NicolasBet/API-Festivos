using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festivos.Infraestructura.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class SyncWithDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateIndex(
                name: "IX_Festivo_IdTipo",
                table: "Festivo",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Festivo");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
