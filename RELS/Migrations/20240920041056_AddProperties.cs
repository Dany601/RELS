using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareMetersProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    PropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypePropertyId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesXOwners_PropertyId",
                table: "PropertiesXOwners",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesXLessors_PropertyId",
                table: "PropertiesXLessors",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXLessors_Properties_PropertyId",
                table: "PropertiesXLessors",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXOwners_Properties_PropertyId",
                table: "PropertiesXOwners",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXLessors_Properties_PropertyId",
                table: "PropertiesXLessors");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXOwners_Properties_PropertyId",
                table: "PropertiesXOwners");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesXOwners_PropertyId",
                table: "PropertiesXOwners");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesXLessors_PropertyId",
                table: "PropertiesXLessors");
        }
    }
}
