using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_Feedback_App.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Feedbacks_FeedbackId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Feedbacks_FeedbackId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_UsersRegs_UserEmail",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersUnregs",
                table: "UsersUnregs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRegs",
                table: "UsersRegs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_UserEmail",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FeedbackId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UsersUnregId",
                table: "UsersUnregs");

            migrationBuilder.DropColumn(
                name: "UsersRegId",
                table: "UsersRegs");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Surveys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Responses",
                newName: "UsersUnregId");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Feedbacks",
                newName: "EndTime");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UsersUnregs",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UsersRegs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UsersRegs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UsersRegs",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "UsersRegs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UsersRegs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UsersRegs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "UsersRegs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UsersRegId",
                table: "Surveys",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UniqueLink",
                table: "Surveys",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Upload",
                table: "Surveys",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FeedbackId",
                table: "Responses",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Responses",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Responses",
                table: "Responses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SurveyId",
                table: "Responses",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SurveyId",
                table: "Questions",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Questions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UsersUnregId",
                table: "Feedbacks",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SurveyId",
                table: "Feedbacks",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Feedbacks",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsersRegId",
                table: "Feedbacks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersUnregs",
                table: "UsersUnregs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRegs",
                table: "UsersRegs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses",
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
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_UsersUnregs_UsersUnregId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Feedbacks_FeedbackId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersUnregs",
                table: "UsersUnregs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRegs",
                table: "UsersRegs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UsersUnregId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersUnregs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersRegs");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "UsersRegs");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UsersRegs");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UsersRegs");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "UsersRegs");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "UniqueLink",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Upload",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Responses",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UsersRegId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Surveys",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "UsersUnregId",
                table: "Responses",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Feedbacks",
                newName: "Time");

            migrationBuilder.AddColumn<int>(
                name: "UsersUnregId",
                table: "UsersUnregs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UsersRegs",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UsersRegs",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsersRegId",
                table: "UsersRegs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsersRegId",
                table: "Surveys",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "FeedbackId",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsersUnregId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersUnregs",
                table: "UsersUnregs",
                column: "UsersUnregId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRegs",
                table: "UsersRegs",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "SurveyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "ResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserEmail",
                table: "Surveys",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FeedbackId",
                table: "Questions",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Surveys_SurveyId",
                table: "Feedbacks",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Feedbacks_FeedbackId",
                table: "Questions",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Feedbacks_FeedbackId",
                table: "Responses",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_UsersRegs_UserEmail",
                table: "Surveys",
                column: "UserEmail",
                principalTable: "UsersRegs",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
