using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExamLogsFix : Migration
    {
        /// <inheritdoc />

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "examLogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamAttemptsid = table.Column<Guid>(type: "uuid", nullable: false),
                    AtemptID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    action = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_examLogs_examAttempts_ExamAttemptsid",
                        column: x => x.ExamAttemptsid,
                        principalTable: "examAttempts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_examLogs_ExamAttemptsid",
                table: "examLogs",
                column: "ExamAttemptsid");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "examLogs");
        }
    }
}
