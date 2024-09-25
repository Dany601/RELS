using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Lessors_LessorId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_People_PersonId",
                table: "Lessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_People_PersonId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_People_TypesDocuments_TypeDocumentDocumentTypeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Sectors_SectorId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_TypesProperties_TypePropertyId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXLessors_Lessors_LessorId",
                table: "PropertiesXLessors");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXLessors_Properties_PropertyId",
                table: "PropertiesXLessors");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXOwners_Owners_OwnerId",
                table: "PropertiesXOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXOwners_Properties_PropertyId",
                table: "PropertiesXOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_PersonId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_SectorId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonId",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors");

            migrationBuilder.DropIndex(
                name: "IX_Lessors_PersonId",
                table: "Lessors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LessorId",
                table: "Lessors");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "UserTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TypePropertyId",
                table: "TypesProperties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DocumentTypeId",
                table: "TypesDocuments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "States",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SectorIdId",
                table: "Sectors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TypePropertyId",
                table: "Properties",
                newName: "TypesPropertiesId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Properties",
                newName: "SectorsId");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Properties",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_TypePropertyId",
                table: "Properties",
                newName: "IX_Properties_TypesPropertiesId");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Permissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TypeDocumentDocumentTypeId",
                table: "People",
                newName: "TypeDocumentId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "People",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_People_TypeDocumentDocumentTypeId",
                table: "People",
                newName: "IX_People_TypeDocumentId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Owners",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Lessors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FavoriteId",
                table: "Favorites",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SectorsId",
                table: "Properties",
                column: "SectorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Lessors_LessorId",
                table: "Documents",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_People_TypesDocuments_TypeDocumentId",
                table: "People",
                column: "TypeDocumentId",
                principalTable: "TypesDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Sectors_SectorsId",
                table: "Properties",
                column: "SectorsId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_TypesProperties_TypesPropertiesId",
                table: "Properties",
                column: "TypesPropertiesId",
                principalTable: "TypesProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXLessors_Lessors_LessorId",
                table: "PropertiesXLessors",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXLessors_Properties_PropertyId",
                table: "PropertiesXLessors",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXOwners_Owners_OwnerId",
                table: "PropertiesXOwners",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXOwners_Properties_PropertyId",
                table: "PropertiesXOwners",
                column: "PropertyId",
                principalTable: "Properties",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Lessors_LessorId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_People_Id",
                table: "Lessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_People_Id",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_People_TypesDocuments_TypeDocumentId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Sectors_SectorsId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_TypesProperties_TypesPropertiesId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXLessors_Lessors_LessorId",
                table: "PropertiesXLessors");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXLessors_Properties_PropertyId",
                table: "PropertiesXLessors");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXOwners_Owners_OwnerId",
                table: "PropertiesXOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesXOwners_Properties_PropertyId",
                table: "PropertiesXOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_Id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_SectorsId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserTypes",
                newName: "UserTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypesProperties",
                newName: "TypePropertyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypesDocuments",
                newName: "DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "States",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sectors",
                newName: "SectorIdId");

            migrationBuilder.RenameColumn(
                name: "TypesPropertiesId",
                table: "Properties",
                newName: "TypePropertyId");

            migrationBuilder.RenameColumn(
                name: "SectorsId",
                table: "Properties",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Properties",
                newName: "SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_TypesPropertiesId",
                table: "Properties",
                newName: "IX_Properties_TypePropertyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Permissions",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "TypeDocumentId",
                table: "People",
                newName: "TypeDocumentDocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "People",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_People_TypeDocumentId",
                table: "People",
                newName: "IX_People_TypeDocumentDocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owners",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessors",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Favorites",
                newName: "FavoriteId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LessorId",
                table: "Lessors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessors",
                table: "Lessors",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SectorId",
                table: "Properties",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonId",
                table: "Owners",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_PersonId",
                table: "Lessors",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Lessors_LessorId",
                table: "Documents",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "LessorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessors_People_PersonId",
                table: "Lessors",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_People_PersonId",
                table: "Owners",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_TypesDocuments_TypeDocumentDocumentTypeId",
                table: "People",
                column: "TypeDocumentDocumentTypeId",
                principalTable: "TypesDocuments",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Sectors_SectorId",
                table: "Properties",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorIdId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_TypesProperties_TypePropertyId",
                table: "Properties",
                column: "TypePropertyId",
                principalTable: "TypesProperties",
                principalColumn: "TypePropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXLessors_Lessors_LessorId",
                table: "PropertiesXLessors",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "LessorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXLessors_Properties_PropertyId",
                table: "PropertiesXLessors",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXOwners_Owners_OwnerId",
                table: "PropertiesXOwners",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesXOwners_Properties_PropertyId",
                table: "PropertiesXOwners",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
