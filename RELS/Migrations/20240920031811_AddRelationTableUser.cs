using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PermissionsXUser_UserTypeId",
                table: "PermissionsXUser",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionsXUser_UserTypes_UserTypeId",
                table: "PermissionsXUser",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionsXUser_UserTypes_UserTypeId",
                table: "PermissionsXUser");

            migrationBuilder.DropIndex(
                name: "IX_PermissionsXUser_UserTypeId",
                table: "PermissionsXUser");
        }
    }
}
