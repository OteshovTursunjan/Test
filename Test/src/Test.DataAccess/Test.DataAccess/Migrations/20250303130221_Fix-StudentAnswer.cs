using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixStudentAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentAnswers_examAttempts_examAttemptsid",
                table: "studentAnswers");

            migrationBuilder.DropColumn(
                name: "AtemptId",
                table: "studentAnswers");

            migrationBuilder.RenameColumn(
                name: "examAttemptsid",
                table: "studentAnswers",
                newName: "examId");

            migrationBuilder.RenameIndex(
                name: "IX_studentAnswers_examAttemptsid",
                table: "studentAnswers",
                newName: "IX_studentAnswers_examId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentAnswers_exams_examId",
                table: "studentAnswers",
                column: "examId",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentAnswers_exams_examId",
                table: "studentAnswers");

            migrationBuilder.RenameColumn(
                name: "examId",
                table: "studentAnswers",
                newName: "examAttemptsid");

            migrationBuilder.RenameIndex(
                name: "IX_studentAnswers_examId",
                table: "studentAnswers",
                newName: "IX_studentAnswers_examAttemptsid");

            migrationBuilder.AddColumn<Guid>(
                name: "AtemptId",
                table: "studentAnswers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_studentAnswers_examAttempts_examAttemptsid",
                table: "studentAnswers",
                column: "examAttemptsid",
                principalTable: "examAttempts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
