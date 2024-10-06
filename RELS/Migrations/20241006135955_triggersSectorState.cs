using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class triggersSectorState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "TypeDocumentHistories",
                newName: "IdTypeDocument");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "StateHistories",
                newName: "IdState");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "SectorHistories",
                newName: "IdSector");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTypeDocument",
                table: "TypeDocumentHistories",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "IdState",
                table: "StateHistories",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "IdSector",
                table: "SectorHistories",
                newName: "UserType");
        }
    }
}
