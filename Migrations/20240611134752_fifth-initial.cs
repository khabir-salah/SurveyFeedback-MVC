using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_Feedback_App.Migrations
{
    /// <inheritdoc />
    public partial class fifthinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_UsersUnregs_UsersUnregId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Feedbacks_FeedbackId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_SurveyId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UsersUnregId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UsersRegId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "UsersUnregId",
                table: "Responses",
                newName: "Response");

            migrationBuilder.RenameColumn(
                name: "Responses",
                table: "Responses",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "Responses",
                newName: "SurveyResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_FeedbackId",
                table: "Responses",
                newName: "IX_Responses_SurveyResponseId");

            migrationBuilder.AlterColumn<string>(
                name: "UsersUnregId",
                table: "Feedbacks",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SurveyId",
                table: "Feedbacks",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Feedbacks_SurveyResponseId",
                table: "Responses",
                column: "SurveyResponseId",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Feedbacks_SurveyResponseId",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "SurveyResponseId",
                table: "Responses",
                newName: "FeedbackId");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "Responses",
                newName: "UsersUnregId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Responses",
                newName: "Responses");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_SurveyResponseId",
                table: "Responses",
                newName: "IX_Responses_FeedbackId");

            migrationBuilder.AddColumn<string>(
                name: "SurveyId",
                table: "Responses",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UsersUnregId",
                table: "Feedbacks",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SurveyId",
                table: "Feedbacks",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Feedbacks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsersRegId",
                table: "Feedbacks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SurveyId",
                table: "Feedbacks",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UsersUnregId",
                table: "Feedbacks",
                column: "UsersUnregId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_UsersUnregs_UsersUnregId",
                table: "Feedbacks",
                column: "UsersUnregId",
                principalTable: "UsersUnregs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Feedbacks_FeedbackId",
                table: "Responses",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
