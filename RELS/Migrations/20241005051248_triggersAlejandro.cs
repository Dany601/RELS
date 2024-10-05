using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class triggersAlejandro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Trigger Person
            migrationBuilder.Sql(@"
        CREATE OR ALTER TRIGGER trg_AuditPerson
        ON [People]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;
            -- If there are inserted or updated records
            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                INSERT INTO PersonHistories (IdPerson, FirstName, SecondName, FirstLastName, SecondLastName, DocumentType, IdentificationNumber, Email, CellPhoneNumber, LandlineTelephone, Pasword, Modified, ModifiedBy)
                SELECT i.Id, i.IdPerson, i.FirstName, i.FirstLastName, i.DocumentType, i.IdentificationNumber, i.Email, i.CellPhoneNumber, i.LandlineTelephone, i.Pasword,
                    GETDATE(),
                        CASE 
                            WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                            ELSE 'INSERT' 
                        END
                FROM inserted i;
            END
 
            -- If there are deleted records
            IF EXISTS (SELECT * FROM deleted)
            BEGIN
                INSERT INTO PersonHistories (IdPerson, FirstName, SecondName, FirstLastName, SecondLastName, DocumentType, IdentificationNumber, Email, CellPhoneNumber, LandlineTelephone, Pasword, Modified, ModifiedBy)
                SELECT d.Id, d.IdPerson, d.FirstName, d.FirstLastName, d.DocumentType, d.IdentificationNumber, d.Email, d.CellPhoneNumber, d.LandlineTelephone, d.Pasword, GETDATE(), 'DELETE'
                        FROM deleted d;
            END
        END;
    ");

            //Trigger Property
            migrationBuilder.Sql(@"
        CREATE OR ALTER TRIGGER trg_AuditProperty
        ON [Properties]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;
            -- If there are inserted or updated records
            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                INSERT INTO PropertyHistories (IdProperty, PropertyAddress, SquareMetersProperty, Cost, PropertyDescription, Latitude, Altitude, Modified, ModifiedBy)
                SELECT i.Id, i.IdProperty, i.PropertyAddress, i.SquareMetersProperty, i.Cost, i.PropertyDescription, i.Latitude, i.Altitude, 
                    GETDATE(),
                        CASE 
                            WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                            ELSE 'INSERT' 
                        END
                FROM inserted i;
            END
 
            -- If there are deleted records
            IF EXISTS (SELECT * FROM deleted)
            BEGIN
                INSERT INTO PropertyHistories (IdProperty, PropertyAddress, SquareMetersProperty, Cost, PropertyDescription, Latitude, Altitude, Modified, ModifiedBy)
                SELECT d.Id, d.IdProperty, d.PropertyAddress, d.SquareMetersProperty, d.Cost, d.PropertyDescription, d.Latitude, d.Altitude,  GETDATE(), 'DELETE'
                        FROM deleted d;
            END
        END;
    ");

            //Trigger TypeProperty
            migrationBuilder.Sql(@"
        CREATE OR ALTER TRIGGER trg_AuditTypeProperty
        ON [TypesProperties]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;
            -- If there are inserted or updated records
            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                INSERT INTO TypePropertyHistories (IdTypeProperty, NameTypeProperty, Modified, ModifiedBy)
                SELECT i.Id, i.IdTypeProperty, i.NameTypeProperty, 
                    GETDATE(),
                        CASE 
                            WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                            ELSE 'INSERT' 
                        END
                FROM inserted i;
            END
 
            -- If there are deleted records
            IF EXISTS (SELECT * FROM deleted)
            BEGIN
                INSERT INTO TypePropertyHistories (IdTypeProperty, NameTypeProperty, Modified, ModifiedBy)
                SELECT d.Id, d.IdTypeProperty, d.NameTypeProperty,  GETDATE(), 'DELETE'
                        FROM deleted d;
            END
        END;
    ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditPerson;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditProperty;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditTypeProperty;");
        }
    }
}
