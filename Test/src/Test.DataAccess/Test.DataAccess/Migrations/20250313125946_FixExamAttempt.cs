//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace Test.DataAccess.Migrations
//{
//    /// <inheritdoc />
//    public partial class FixExamAttempt : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_examAttempts_AspNetUsers_UserId",
//                table: "examAttempts");

//            migrationBuilder.DropForeignKey(
//                name: "FK_examAttempts_exams_ExamId",
//                table: "examAttempts");

//            migrationBuilder.DropIndex(
//                name: "IX_examAttempts_ExamId",
//                table: "examAttempts");

    

//            migrationBuilder.DropColumn(
//                name: "ExamId",
//                table: "examAttempts");

//            migrationBuilder.DropColumn(
//                name: "Score",
//                table: "examAttempts");

//            migrationBuilder.DropColumn(
//                name: "UserId",
//                table: "examAttempts");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.AddColumn<Guid>(
//                name: "ExamId",
//                table: "examAttempts",
//                type: "uuid",
//                nullable: false,
//                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

//            migrationBuilder.AddColumn<int>(
//                name: "Score",
//                table: "examAttempts",
//                type: "integer",
//                nullable: false,
//                defaultValue: 0);

//            migrationBuilder.AddColumn<string>(
//                name: "UserId",
//                table: "examAttempts",
//                type: "text",
//                nullable: true);

//            migrationBuilder.CreateIndex(
//                name: "IX_examAttempts_ExamId",
//                table: "examAttempts",
//                column: "ExamId");

           

//            migrationBuilder.AddForeignKey(
//                name: "FK_examAttempts_AspNetUsers_UserId",
//                table: "examAttempts",
//                column: "UserId",
//                principalTable: "AspNetUsers",
//                principalColumn: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_examAttempts_exams_ExamId",
//                table: "examAttempts",
//                column: "ExamId",
//                principalTable: "exams",
//                principalColumn: "id",
//                onDelete: ReferentialAction.Cascade);
//        }
//    }
//}
