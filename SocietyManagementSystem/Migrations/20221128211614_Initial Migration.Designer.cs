﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocietyManagementSystem.Data;

#nullable disable

namespace SocietyManagementSystem.Migrations
{
    [DbContext(typeof(SocietyManagementDbContext))]
    [Migration("20221128211614_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Event_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guest_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocietyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("SocietyName");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.FinanceDepartment", b =>
                {
                    b.Property<string>("BudgetApproverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BudgetApproverId");

                    b.ToTable("FinanceDepartments");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Registration", b =>
                {
                    b.Property<Guid>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RegistrationId");

                    b.HasIndex("EventId");

                    b.HasIndex("StudentId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Society", b =>
                {
                    b.Property<string>("SocietyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Announcement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("BudgetApproverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Faculty_cohead_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faculty_head_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gs_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("President_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Treasurer_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vice_president_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocietyName");

                    b.HasIndex("BudgetApproverId");

                    b.HasIndex("Faculty_head_id");

                    b.HasIndex("President_id");

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Teacher", b =>
                {
                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Employement_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Event", b =>
                {
                    b.HasOne("SocietyManagementSystem.Models.Entities.Society", "Society")
                        .WithMany()
                        .HasForeignKey("SocietyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Society");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Registration", b =>
                {
                    b.HasOne("SocietyManagementSystem.Models.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocietyManagementSystem.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SocietyManagementSystem.Models.Entities.Society", b =>
                {
                    b.HasOne("SocietyManagementSystem.Models.Entities.FinanceDepartment", "FinanceDepartment")
                        .WithMany()
                        .HasForeignKey("BudgetApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocietyManagementSystem.Models.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("Faculty_head_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocietyManagementSystem.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("President_id");

                    b.Navigation("FinanceDepartment");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
