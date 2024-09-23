using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class TypesPropertiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_State_StateId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "StateId");

            migrationBuilder.CreateTable(
                name: "TypesProperties",
                columns: table => new
                {
                    TypePropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeProperty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProperties", x => x.TypePropertyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TypePropertyId",
                table: "Properties",
                column: "TypePropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_States_StateId",
                table: "Properties",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_TypesProperties_TypePropertyId",
                table: "Properties",
                column: "TypePropertyId",
                principalTable: "TypesProperties",
                principalColumn: "TypePropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_States_StateId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_TypesProperties_TypePropertyId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "TypesProperties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_TypePropertyId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_State_StateId",
                table: "Properties",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
