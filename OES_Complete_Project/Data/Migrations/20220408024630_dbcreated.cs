using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES_Complete_Project.Data.Migrations
{
    public partial class dbcreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfCompletion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    Technology_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Technology_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.Technology_ID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Question_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Technology_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technology_ID1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Correct_Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Question_ID);
                    table.ForeignKey(
                        name: "FK_Questions_Technology_Technology_ID1",
                        column: x => x.Technology_ID1,
                        principalTable: "Technology",
                        principalColumn: "Technology_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Exam_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marks1 = table.Column<int>(type: "int", nullable: false),
                    Marks2 = table.Column<int>(type: "int", nullable: false),
                    Marks3 = table.Column<int>(type: "int", nullable: false),
                    Technology_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technology_ID1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Exam_ID);
                    table.ForeignKey(
                        name: "FK_Reports_Technology_Technology_ID1",
                        column: x => x.Technology_ID1,
                        principalTable: "Technology",
                        principalColumn: "Technology_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Technology_ID1",
                table: "Questions",
                column: "Technology_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Technology_ID1",
                table: "Reports",
                column: "Technology_ID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Technology");
        }
    }
}
