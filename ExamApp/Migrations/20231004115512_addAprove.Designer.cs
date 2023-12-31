﻿// <auto-generated />
using System;
using ExamApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamApp.Migrations
{
    [DbContext(typeof(myDbContext))]
    [Migration("20231004115512_addAprove")]
    partial class addAprove
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamApp.AtachFile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrackerId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("TrackerId");

                    b.ToTable("atachFiles");
                });

            modelBuilder.Entity("ExamApp.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("ExamApp.Trackers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("In_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("In_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Out_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Out_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReciverId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<bool?>("isApprove")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("trackers");
                });

            modelBuilder.Entity("ExamApp.AtachFile", b =>
                {
                    b.HasOne("ExamApp.Trackers", "Trackers")
                        .WithMany()
                        .HasForeignKey("TrackerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trackers");
                });

            modelBuilder.Entity("ExamApp.Trackers", b =>
                {
                    b.HasOne("ExamApp.Department", "Department")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
