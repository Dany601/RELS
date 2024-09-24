using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesXLessors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyXOwner_Owner_OwnerId",
                table: "PropertyXOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessor",
                table: "Lessor");

            migrationBuilder.RenameTable(
                name: "PropertyXOwner",
                newName: "PropertiesXOwners");

            migrationBuilder.RenameTable(
                name: "Lessor",
                newName: "Lessors");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyXOwner_OwnerId",
                table: "PropertiesXOwners",
                newName: "IX_PropertiesXOwners_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors",
                column: "LessorId");

            migrationBuilder.CreateTable(
                name: "PropertiesXLessors",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    LessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PropertiesXLessors_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalTable: "Lessors",
                        principalColumn: "LessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesXLessors_LessorId",
                table: "PropertiesXLessors",
                column: "LessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXOwners_Owner_OwnerId",
                table: "PropertiesXOwners",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXOwners_Owner_OwnerId",
                table: "PropertiesXOwners");

            migrationBuilder.DropTable(
                name: "PropertiesXLessors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors");

            migrationBuilder.RenameTable(
                name: "PropertiesXOwners",
                newName: "PropertyXOwner");

            migrationBuilder.RenameTable(
                name: "Lessors",
                newName: "Lessor");

            migrationBuilder.RenameIndex(
                name: "IX_PropertiesXOwners_OwnerId",
                table: "PropertyXOwner",
                newName: "IX_PropertyXOwner_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessor",
                table: "Lessor",
                column: "LessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyXOwner_Owner_OwnerId",
                table: "PropertyXOwner",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
