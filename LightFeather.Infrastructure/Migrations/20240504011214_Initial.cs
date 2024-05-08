using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightFeather.CodeChallenge.Infrastructure.Migrations;

/// <inheritdoc/>
public partial class Initial : Migration
{
    /// <inheritdoc/>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "SubmitSupervisorEntities",
            columns: table =>
            {
                return new
                {
                    Id = table.Column<long>(type: "bigint",nullable: false)
                                    .Annotation("SqlServer:Identity","1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)",maxLength: 50,nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)",maxLength: 50,nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)",maxLength: 100,nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)",maxLength: 50,nullable: true),
                    Supervisor = table.Column<string>(type: "nvarchar(250)",maxLength: 250,nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2",nullable: false,defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2",nullable: false,defaultValueSql: "GETDATE()")
                };
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_SubmitSupervisorEntities",x => x.Id);
            });
    }

    /// <inheritdoc/>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "SubmitSupervisorEntities");
    }
}