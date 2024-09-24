using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documents_LessorId",
                table: "Documents",
                column: "LessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Lessors_LessorId",
                table: "Documents",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "LessorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Lessors_LessorId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_LessorId",
                table: "Documents");
        }
    }
}
