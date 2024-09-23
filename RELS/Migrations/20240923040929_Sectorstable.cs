using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class Sectorstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorIdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerctorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorIdId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SectorId",
                table: "Properties",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Sectors_SectorId",
                table: "Properties",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorIdId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Sectors_SectorId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Properties_SectorId",
                table: "Properties");
        }
    }
}
