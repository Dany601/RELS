using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesXOwners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors");

            migrationBuilder.RenameTable(
                name: "Lessors",
                newName: "Lessor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessor",
                table: "Lessor",
                column: "LessorId");

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyXOwner",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PropertyXOwner_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyXOwner_OwnerId",
                table: "PropertyXOwner",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyXOwner");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessor",
                table: "Lessor");

            migrationBuilder.RenameTable(
                name: "Lessor",
                newName: "Lessors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors",
                column: "LessorId");
        }
    }
}
