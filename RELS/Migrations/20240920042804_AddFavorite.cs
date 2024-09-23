using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddFavorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteId",
                table: "PropertiesXLessors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesXLessors_FavoriteId",
                table: "PropertiesXLessors",
                column: "FavoriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXLessors_Favorites_FavoriteId",
                table: "PropertiesXLessors",
                column: "FavoriteId",
                principalTable: "Favorites",
                principalColumn: "FavoriteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXLessors_Favorites_FavoriteId",
                table: "PropertiesXLessors");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesXLessors_FavoriteId",
                table: "PropertiesXLessors");

            migrationBuilder.DropColumn(
                name: "FavoriteId",
                table: "PropertiesXLessors");
        }
    }
}
