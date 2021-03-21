﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(CisEngDbContext))]
    [Migration("20210320144255_resToresSelfJoin")]
    partial class resToresSelfJoin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.ApplyJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CisStudentId");

                    b.Property<string>("Content");

                    b.Property<int?>("JobId");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.HasIndex("JobId");

                    b.ToTable("ApplyJobs");
                });

            modelBuilder.Entity("Domain.Entities.ApplyTraining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CisStudentId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int?>("TrainingId");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.HasIndex("TrainingId");

                    b.ToTable("ApplyTrainings");
                });

            modelBuilder.Entity("Domain.Entities.CisStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CisStudents");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CisStudentId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Entities.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CisStudentRecieveId");

                    b.Property<int?>("CisStudentSendId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsAccepte");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentRecieveId");

                    b.HasIndex("CisStudentSendId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CisStudentId");

                    b.Property<string>("ContactUs");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Place");

                    b.Property<string>("Technology");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CisStudentId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addition");

                    b.Property<string>("Age");

                    b.Property<string>("Appreciation");

                    b.Property<string>("Carear");

                    b.Property<int>("CisStudentId");

                    b.Property<string>("City");

                    b.Property<string>("Colleage");

                    b.Property<string>("Company");

                    b.Property<string>("Experience");

                    b.Property<string>("Language");

                    b.Property<string>("Programing_Language");

                    b.Property<string>("University");

                    b.Property<string>("kind");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Domain.Entities.ResponseToComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CisStudentId");

                    b.Property<int?>("CommentId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.HasIndex("CommentId");

                    b.ToTable("ResponseToComments");
                });

            modelBuilder.Entity("Domain.Entities.ResponseToResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CisStudentId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int?>("ResponseId");

                    b.Property<int?>("ResponseToCommentId");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.HasIndex("ResponseId");

                    b.HasIndex("ResponseToCommentId");

                    b.ToTable("ResponseToResponses");
                });

            modelBuilder.Entity("Domain.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CisStudentId");

                    b.Property<string>("Content");

                    b.Property<string>("CreateDate");

                    b.Property<string>("Place");

                    b.Property<string>("Technology");

                    b.HasKey("Id");

                    b.HasIndex("CisStudentId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Domain.Entities.ApplyJob", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("ApplyJobs")
                        .HasForeignKey("CisStudentId");

                    b.HasOne("Domain.Entities.Job", "Job")
                        .WithMany("Applies")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("Domain.Entities.ApplyTraining", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("ApplyTrainings")
                        .HasForeignKey("CisStudentId");

                    b.HasOne("Domain.Entities.Training", "Training")
                        .WithMany("Applies")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("Comments")
                        .HasForeignKey("CisStudentId");

                    b.HasOne("Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Domain.Entities.Follow", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudentRecieve")
                        .WithMany("ReceiveFollow")
                        .HasForeignKey("CisStudentRecieveId");

                    b.HasOne("Domain.Entities.CisStudent", "CisStudentSend")
                        .WithMany("SendFollow")
                        .HasForeignKey("CisStudentSendId");
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("Jobs")
                        .HasForeignKey("CisStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("Posts")
                        .HasForeignKey("CisStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Profile", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany()
                        .HasForeignKey("CisStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ResponseToComment", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("ResponseToComments")
                        .HasForeignKey("CisStudentId");

                    b.HasOne("Domain.Entities.Comment", "Comment")
                        .WithMany("ResponseToComments")
                        .HasForeignKey("CommentId");
                });

            modelBuilder.Entity("Domain.Entities.ResponseToResponse", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("ResponseToResponses")
                        .HasForeignKey("CisStudentId");

                    b.HasOne("Domain.Entities.ResponseToResponse", "ResponseToRes")
                        .WithMany("ResponseToResponses")
                        .HasForeignKey("ResponseId");

                    b.HasOne("Domain.Entities.ResponseToComment", "Comment")
                        .WithMany("ResponseToResponses")
                        .HasForeignKey("ResponseToCommentId");
                });

            modelBuilder.Entity("Domain.Entities.Training", b =>
                {
                    b.HasOne("Domain.Entities.CisStudent", "CisStudent")
                        .WithMany("Trainings")
                        .HasForeignKey("CisStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
