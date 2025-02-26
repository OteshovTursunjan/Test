using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixExamAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfAttempt",
                table: "examAttempts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfAttempt",
                table: "examAttempts");
        }
    }
}
