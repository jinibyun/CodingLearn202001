﻿// <auto-generated />
using System;
using EFCoreConsole.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreConsole.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190606234032_addTest3")]
    partial class addTest3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreConsole.Model.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<int?>("TeacherId");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionName");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName");

                    b.Property<string>("Section");

                    b.HasKey("GradeId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Standard", b =>
                {
                    b.Property<int>("StandardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("StandardName");

                    b.HasKey("StandardId");

                    b.ToTable("Standard");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<int?>("GradeId");

                    b.Property<decimal>("Height");

                    b.Property<byte[]>("Photo");

                    b.Property<int?>("StandardId");

                    b.Property<string>("StudentName");

                    b.Property<float>("Weight");

                    b.HasKey("StudentID");

                    b.HasIndex("GradeId");

                    b.HasIndex("StandardId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFCoreConsole.Model.StudentAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("State");

                    b.Property<int>("StudentID");

                    b.HasKey("Id");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentAddress");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StandardId");

                    b.Property<string>("TeacherName");

                    b.Property<int?>("TeacherType");

                    b.HasKey("TeacherId");

                    b.HasIndex("StandardId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Course", b =>
                {
                    b.HasOne("EFCoreConsole.Model.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("EFCoreConsole.Model.Student", b =>
                {
                    b.HasOne("EFCoreConsole.Model.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId");

                    b.HasOne("EFCoreConsole.Model.Standard")
                        .WithMany("Students")
                        .HasForeignKey("StandardId");
                });

            modelBuilder.Entity("EFCoreConsole.Model.StudentAddress", b =>
                {
                    b.HasOne("EFCoreConsole.Model.Student", "Student")
                        .WithMany("StudentAddresses")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreConsole.Model.Teacher", b =>
                {
                    b.HasOne("EFCoreConsole.Model.Standard", "Standard")
                        .WithMany("Teachers")
                        .HasForeignKey("StandardId");
                });
#pragma warning restore 612, 618
        }
    }
}
