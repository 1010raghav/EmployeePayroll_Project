using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeRepository.Migrations
{
    public partial class emplyee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    FullName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    StartDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.FullName);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.FirstName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
