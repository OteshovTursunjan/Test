using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Test7L : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_exams_Examid",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Examid",
                table: "Sessions",
                newName: "ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_Examid",
                table: "Sessions",
                newName: "IX_Sessions_ExamID");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamSessionID",
                table: "studentAnswers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_studentAnswers_ExamSessionID",
                table: "studentAnswers",
                column: "ExamSessionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_exams_ExamID",
                table: "Sessions",
                column: "ExamID",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentAnswers_Sessions_ExamSessionID",
                table: "studentAnswers",
                column: "ExamSessionID",
                principalTable: "Sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_exams_ExamID",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_studentAnswers_Sessions_ExamSessionID",
                table: "studentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_studentAnswers_ExamSessionID",
                table: "studentAnswers");

            migrationBuilder.DropColumn(
                name: "ExamSessionID",
                table: "studentAnswers");

            migrationBuilder.RenameColumn(
                name: "ExamID",
                table: "Sessions",
                newName: "Examid");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_ExamID",
                table: "Sessions",
                newName: "IX_Sessions_Examid");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_exams_Examid",
                table: "Sessions",
                column: "Examid",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
