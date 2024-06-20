using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_Feedback_App.Migrations
{
    /// <inheritdoc />
    public partial class elenthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "Feedbacks",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_QuestionId",
                table: "Feedbacks",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Questions_QuestionId",
                table: "Feedbacks",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Questions_QuestionId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_QuestionId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Feedbacks");
        }
    }
}
