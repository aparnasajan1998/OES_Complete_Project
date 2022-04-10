using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES_Complete_Project.Data.Migrations
{
    public partial class dealdee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "StudentsUser_ID",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_StudentsUser_ID",
                table: "Reports",
                column: "StudentsUser_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Students_StudentsUser_ID",
                table: "Reports",
                column: "StudentsUser_ID",
                principalTable: "Students",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Students_StudentsUser_ID",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_StudentsUser_ID",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StudentsUser_ID",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "User_ID",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
