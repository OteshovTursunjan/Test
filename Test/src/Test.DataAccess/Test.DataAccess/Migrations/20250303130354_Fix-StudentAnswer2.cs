using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixStudentAnswer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentAnswers_exams_examId",
                table: "studentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_studentAnswers_examId",
                table: "studentAnswers");

            migrationBuilder.DropColumn(
                name: "examId",
                table: "studentAnswers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "examId",
                table: "studentAnswers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_studentAnswers_examId",
                table: "studentAnswers",
                column: "examId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentAnswers_exams_examId",
                table: "studentAnswers",
                column: "examId",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
