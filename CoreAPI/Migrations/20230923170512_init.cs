using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "UserLoginDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginDetail_EmployeeId",
                table: "UserLoginDetail",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginDetail_EmployeeDetail_EmployeeId",
                table: "UserLoginDetail",
                column: "EmployeeId",
                principalTable: "EmployeeDetail",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginDetail_EmployeeDetail_EmployeeId",
                table: "UserLoginDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginDetail_EmployeeId",
                table: "UserLoginDetail");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserLoginDetail");
        }
    }
}
