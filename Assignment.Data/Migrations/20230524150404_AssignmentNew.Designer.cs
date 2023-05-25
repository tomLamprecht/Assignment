﻿// <auto-generated />
using System;
using Assignment.Data.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Data.Migrations
{
    [DbContext(typeof(AssignmentContext))]
    [Migration("20230524150404_AssignmentNew")]
    partial class AssignmentNew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment.Data.Models.Domains.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"));

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Firm")
                        .HasColumnType("bit");

                    b.Property<string>("Offer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ApplicationId");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Assignment.Data.Models.Domains.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniversityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UniversityId");

                    b.HasIndex("UserId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Assignment.Data.Models.Domains.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Assignment.Data.Models.Domains.Application", b =>
                {
                    b.HasOne("Assignment.Data.Models.Domains.University", null)
                        .WithMany("Applications")
                        .HasForeignKey("UniversityId");

                    b.HasOne("Assignment.Data.Models.Domains.User", null)
                        .WithMany("Applications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Assignment.Data.Models.Domains.University", b =>
                {
                    b.HasOne("Assignment.Data.Models.Domains.User", null)
                        .WithMany("Universities")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Assignment.Data.Models.Domains.University", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("Assignment.Data.Models.Domains.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Universities");
                });
#pragma warning restore 612, 618
        }
    }
}
