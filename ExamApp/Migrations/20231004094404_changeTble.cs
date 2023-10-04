using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Migrations
{
    public partial class changeTble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incomingLetter");

            migrationBuilder.DropTable(
                name: "outGoingLetter");

            migrationBuilder.DropTable(
                name: "letterType");

            migrationBuilder.DropTable(
                name: "priority");

            migrationBuilder.CreateTable(
                name: "trackers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReciverId = table.Column<int>(type: "int", nullable: false),
                    In_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Out_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Out_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trackers_department_SenderId",
                        column: x => x.SenderId,
                        principalTable: "department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atachFiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atachFiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_atachFiles_trackers_TrackerId",
                        column: x => x.TrackerId,
                        principalTable: "trackers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atachFiles_TrackerId",
                table: "atachFiles",
                column: "TrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_trackers_SenderId",
                table: "trackers",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atachFiles");

            migrationBuilder.DropTable(
                name: "trackers");

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
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LetterTypeId = table.Column<int>(type: "int", nullable: false),
                    AttachFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncommingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    LetterSubject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaktobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    AttachFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LetterSubject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaktobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutGoingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutGoingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
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
    }
}
