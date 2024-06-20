﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survey_Feedback_App.Infastructor.Context;

#nullable disable

namespace Survey_Feedback_App.Migrations
{
    [DbContext(typeof(SurveyFeedbackContext))]
    [Migration("20240618103919_elenth-migration")]
    partial class elenthmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Option", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SurveyId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.QuestionResponse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OptionId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SurveyResponseId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyResponseId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Survey", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TmeCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Upload")
                        .HasColumnType("longtext");

                    b.Property<string>("UsersRegId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.SurveyResponse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("QuestionId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SurveyId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UsersUnregId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UsersUnregId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.UsersReg", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UsersRegs");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.UsersUnreg", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UsersUnregs");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Option", b =>
                {
                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Question", b =>
                {
                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.Survey", "Surveys")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Surveys");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.QuestionResponse", b =>
                {
                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.Option", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.SurveyResponse", null)
                        .WithMany("QuestionResponses")
                        .HasForeignKey("SurveyResponseId");

                    b.Navigation("Option");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.SurveyResponse", b =>
                {
                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survey_Feedback_App.Core.Domain.Entities.UsersUnreg", "UserUnreg")
                        .WithMany()
                        .HasForeignKey("UsersUnregId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Survey");

                    b.Navigation("UserUnreg");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.Survey", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Survey_Feedback_App.Core.Domain.Entities.SurveyResponse", b =>
                {
                    b.Navigation("QuestionResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
