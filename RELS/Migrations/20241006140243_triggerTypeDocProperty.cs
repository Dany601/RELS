using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class triggerTypeDocProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                SELECT i.Id, i.NameTypeProperty,
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
                SELECT d.Id, d.NameTypeProperty, GETDATE(), 'DELETE'
                        FROM deleted d;
            END
        END;
    ");
            //Trigger TypeDocument
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditTypeDocument
            ON [TypesDocuments]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO TypeDocumentHistories (IdTypeDocument, Name, Modified, ModifiedBy)
                    SELECT i.Id, i.Name,
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
                    INSERT INTO TypeDocumentHistories (IdTypeDocument, Name, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");
            //Trigger State
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditState
            ON [States]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO StateHistories (IdState, Name, Modified, ModifiedBy)
                    SELECT i.Id, i.Name,
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
                    INSERT INTO StateHistories (IdState, Name, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");
            //Trigger Sector
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditSector
            ON [Sectors]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO SectorHistories (IdSector, SerctorName, Modified, ModifiedBy)
                    SELECT i.Id, i.SerctorName,
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
                    INSERT INTO SectorHistories (IdSector, SerctorName, Modified, ModifiedBy)
                    SELECT d.Id, d.SerctorName, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditTypeProperty;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditTypeDocument;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditState;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditState;");
        }

    }
}
