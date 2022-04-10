using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES_Complete_Project.Data.Migrations
{
    public partial class dbchnged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Technology_Technology_ID1",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Technology_Technology_ID1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Technology_ID1",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Technology_ID1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Technology_ID1",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Technology_ID1",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "Technology_ID",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Technology_ID",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Technology_ID",
                table: "Reports",
                column: "Technology_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Technology_ID",
                table: "Questions",
                column: "Technology_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Technology_Technology_ID",
                table: "Questions",
                column: "Technology_ID",
                principalTable: "Technology",
                principalColumn: "Technology_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Technology_Technology_ID",
                table: "Reports",
                column: "Technology_ID",
                principalTable: "Technology",
                principalColumn: "Technology_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Technology_Technology_ID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Technology_Technology_ID",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Technology_ID",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Technology_ID",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "Technology_ID",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Technology_ID1",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Technology_ID",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Technology_ID1",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Technology_ID1",
                table: "Reports",
                column: "Technology_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Technology_ID1",
                table: "Questions",
                column: "Technology_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Technology_Technology_ID1",
                table: "Questions",
                column: "Technology_ID1",
                principalTable: "Technology",
                principalColumn: "Technology_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Technology_Technology_ID1",
                table: "Reports",
                column: "Technology_ID1",
                principalTable: "Technology",
                principalColumn: "Technology_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
