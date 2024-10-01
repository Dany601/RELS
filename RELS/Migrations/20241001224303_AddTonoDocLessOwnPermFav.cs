using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class AddTonoDocLessOwnPermFav : Migration
    {
        //// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// <inheritdoc />
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


        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditDocument;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditFavorite;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditLessor;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditOwner;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditPermission;");
        }
    }
}
