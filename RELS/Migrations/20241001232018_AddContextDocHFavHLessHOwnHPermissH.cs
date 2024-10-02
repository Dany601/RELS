using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddContextDocHFavHLessHOwnHPermissH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_People_Id",
                table: "Lessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_People_Id",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Owners",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Lessors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Lessors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_UserId",
                table: "People",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonId",
                table: "Owners",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_PersonId",
                table: "Lessors",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessors_People_PersonId",
                table: "Lessors",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_People_PersonId",
                table: "Owners",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Users_UserId",
                table: "People",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_People_PersonId",
                table: "Lessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_People_PersonId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Users_UserId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_UserId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Lessors_PersonId",
                table: "Lessors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Lessors");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Owners",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Lessors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessors_People_Id",
                table: "Lessors",
                column: "Id",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_People_Id",
                table: "Owners",
                column: "Id",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_Id",
                table: "Users",
                column: "Id",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
