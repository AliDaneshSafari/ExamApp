using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Migrations
{
    public partial class addAllTble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "letterType",
                columns: table => new
                {
                    LetteryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_letterType", x => x.LetteryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "priority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "incomingLetter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaktobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncommingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterSubject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LetterTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incomingLetter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incomingLetter_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incomingLetter_letterType_LetterTypeId",
                        column: x => x.LetterTypeId,
                        principalTable: "letterType",
                        principalColumn: "LetteryTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "outGoingLetter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaktobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutGoingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterSubject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    AttachFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutGoingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outGoingLetter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_outGoingLetter_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_outGoingLetter_priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_incomingLetter_DepartmentId",
                table: "incomingLetter",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_incomingLetter_LetterTypeId",
                table: "incomingLetter",
                column: "LetterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_outGoingLetter_DepartmentId",
                table: "outGoingLetter",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_outGoingLetter_PriorityId",
                table: "outGoingLetter",
                column: "PriorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incomingLetter");

            migrationBuilder.DropTable(
                name: "outGoingLetter");

            migrationBuilder.DropTable(
                name: "letterType");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "priority");
        }
    }
}
