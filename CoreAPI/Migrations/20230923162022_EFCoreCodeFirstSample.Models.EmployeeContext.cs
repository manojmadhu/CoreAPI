using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class EFCoreCodeFirstSampleModelsEmployeeContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDetail",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetail", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginDetail",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginDetail", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetail");

            migrationBuilder.DropTable(
                name: "UserLoginDetail");
        }
    }
}
