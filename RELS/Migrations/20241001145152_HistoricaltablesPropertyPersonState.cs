using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class HistoricaltablesPropertyPersonState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserTypeHistories");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserTypeHistories");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserTypeHistories");

            migrationBuilder.CreateTable(
                name: "PersonHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandlineTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareMetersProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectorHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonHistories");

            migrationBuilder.DropTable(
                name: "PropertyHistories");

            migrationBuilder.DropTable(
                name: "SectorHistories");

            migrationBuilder.DropTable(
                name: "StateHistories");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserTypeHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserTypeHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserTypeHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
