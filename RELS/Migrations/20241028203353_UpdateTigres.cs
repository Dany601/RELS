using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTigres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Trigger UserType
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditUserType
            ON [UserTypes]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO UserTypeHistories (IdUsertype, Name, Modified, ModifiedBy)
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
                    INSERT INTO UserTypeHistories (IdUsertype, Name, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, GETDATE(), 'DELETE'
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
            //Trigger Document
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditDocument
            ON [Documents]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO DocumentHistories (IdDocument, FileRoute, Date, Lessor, Modified, ModifiedBy)
                    SELECT i.Id, i.FileRoute,i.Date, i.LessorId,
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
                    INSERT INTO DocumentHistories (IdDocument, FileRoute, Date, Lessor, Modified, ModifiedBy)
                    SELECT d.Id, d.FileRoute, d.Date, d.LessorId, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            //Trigger Favorite
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditFavorite
            ON [Favorites]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO FavoriteHistories (IdFavorite, Name, Modified, ModifiedBy)
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
                    INSERT INTO FavoriteHistories (IdFavorite, Name, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");


            //Trigger Lessor
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditLessor
            ON [Lessors]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO LessorHistories (IdLessor, Modified, ModifiedBy)
                    SELECT i.Id,
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
                    INSERT INTO LessorHistories (IdLessor, Modified, ModifiedBy)
                    SELECT d.Id, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            //Trigger Owner
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditOwner
            ON [Owners]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO OwnerHistories (IdOwner, Modified, ModifiedBy)
                    SELECT i.Id,
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
                    INSERT INTO OwnerHistories (IdOwner, Modified, ModifiedBy)
                    SELECT d.Id, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            //Trigger Permission
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditPermission
            ON [Permissions]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO PermissionHistories (IdPermission, Name, Modified, ModifiedBy)
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
                    INSERT INTO PermissionHistories (IdPermission, Name, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            //Trigger User
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditUser
            ON [Users]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
            SET NOCOUNT ON;
            -- If there are inserted or updated records
            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                INSERT INTO 
                        UserHistories ( 
                                IdUser,
                                Name,
                                LastName,
                                Email,
                                Password,
                                Identification,
                                CellPhoneNumber,        
                                TypeDocument,
                                Usertype,
                                Modified,
                                ModifiedBy)
                SELECT  
                                i.Id,  
                                i.Name,
                                i.LastName,
                                i.Email,
                                i.Password,
                                i.Identification,
                                i.CellPhoneNumber,
                                i.TypeDocumentId,
                                i.UserTypeId,
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
                INSERT INTO UserHistories (
                        IdUser,
                        Name,
                        LastName,
                        Email,
                        Password,
                        Identification,
                        CellPhoneNumber,
                        TypeDocument, 
                        UserType, 
                        Modified, 
                        ModifiedBy)
                SELECT 
                        d.Id,
                        d.Name,
                        d.LastName,
                        d.Email,
                        d.Password,
                        d.Identification,
                        d.CellPhoneNumber,
                        d.TypeDocumentId, 
                        d.UserTypeId, 
                        GETDATE(),
                        'DELETE'
                        FROM deleted d;
            END
            END;
           ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditUserType;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditTypeProperty;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditTypeDocument;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditState;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditState;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditDocument;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditFavorite;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditLessor;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditOwner;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditPermission;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditUser;");
        }
    }
}
