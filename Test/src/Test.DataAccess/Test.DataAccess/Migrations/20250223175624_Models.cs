using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FacultyID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_subjects_faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionCount = table.Column<int>(type: "integer", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_exams_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    StudentID = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fails", x => x.id);
                    table.ForeignKey(
                        name: "FK_fails_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fails_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "examAttempts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examAttempts", x => x.id);
                    table.ForeignKey(
                        name: "FK_examAttempts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_examAttempts_exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentResult",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    StudentID = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Percentage = table.Column<double>(type: "double precision", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentResult", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentResult_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_studentResult_exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "examLogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ExamAttemptsid = table.Column<Guid>(type: "uuid", nullable: false),
                    AtemptID = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uuid", nullable: false),
                    A = table.Column<string>(type: "text", nullable: false),
                    B = table.Column<string>(type: "text", nullable: false),
                    C = table.Column<string>(type: "text", nullable: false),
                    D = table.Column<string>(type: "text", nullable: false),
                    RightAnswer = table.Column<string>(type: "text", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_answers_questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentAnswers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    examAttemptsid = table.Column<Guid>(type: "uuid", nullable: false),
                    AtemptId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectAnswer = table.Column<string>(type: "text", nullable: false),
                    CreatBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBY = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentAnswers", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentAnswers_examAttempts_examAttemptsid",
                        column: x => x.examAttemptsid,
                        principalTable: "examAttempts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentAnswers_questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_QuestionID",
                table: "answers",
                column: "QuestionID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_examAttempts_ExamId",
                table: "examAttempts",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_examAttempts_UserId",
                table: "examAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_examLogs_ExamAttemptsid",
                table: "examLogs",
                column: "ExamAttemptsid");

            migrationBuilder.CreateIndex(
                name: "IX_exams_SubjectId",
                table: "exams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_fails_ApplicationUserId",
                table: "fails",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_fails_SubjectId",
                table: "fails",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_ExamId",
                table: "questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_studentAnswers_examAttemptsid",
                table: "studentAnswers",
                column: "examAttemptsid");

            migrationBuilder.CreateIndex(
                name: "IX_studentAnswers_QuestionID",
                table: "studentAnswers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_studentResult_ExamId",
                table: "studentResult",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_studentResult_UserId",
                table: "studentResult",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_FacultyID",
                table: "subjects",
                column: "FacultyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "examLogs");

            migrationBuilder.DropTable(
                name: "fails");

            migrationBuilder.DropTable(
                name: "studentAnswers");

            migrationBuilder.DropTable(
                name: "studentResult");

            migrationBuilder.DropTable(
                name: "examAttempts");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "faculties");
        }
    }
}
