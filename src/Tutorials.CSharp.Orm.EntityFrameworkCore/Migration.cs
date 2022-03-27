using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorials.CSharp.Orm.EntityFrameworkCore
{
    public partial class DatabaseInitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    ID = table.Column<int>("int", nullable: false, name: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false, name: "FirstName"),
                    LASTNAME = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false, name: "LastName")
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.ID); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Users");
        }
    }
}