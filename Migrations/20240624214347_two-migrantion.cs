using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_Feedback_App.Migrations
{
    /// <inheritdoc />
    public partial class twomigrantion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyCount",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ResponseCount",
                table: "Feedbacks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyCount",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResponseCount",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
