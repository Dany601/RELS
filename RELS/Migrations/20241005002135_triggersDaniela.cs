using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RELS.Migrations
{
    /// <inheritdoc />
    public partial class triggersDaniela : Migration
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
                INSERT INTO UserHistories (IdUser, Usertype, Modified, ModifiedBy)
                SELECT i.Id, i.UserTypeId,
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
                INSERT INTO UserHistories (IdUser, Usertype, Modified, ModifiedBy)
                SELECT d.Id, d.UserTypeId, GETDATE(), 'DELETE'
                        FROM deleted d;
            END
        END;
    ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditUserType;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditUser;");
        }
    }
}
