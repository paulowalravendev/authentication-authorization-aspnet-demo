﻿// <auto-generated />
using System;
using ConfArch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfArch.Web.Migrations
{
    [DbContext(typeof(ConfArchDbContext))]
    [Migration("20220312071049_AddUsers")]
    partial class AddUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConfArch.Data.Entities.Attendee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ConferenceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Attendees");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConferenceId = 1L,
                            Name = "Lisa Overthere"
                        },
                        new
                        {
                            Id = 2L,
                            ConferenceId = 1L,
                            Name = "Robin Eisenberg"
                        },
                        new
                        {
                            Id = 3L,
                            ConferenceId = 2L,
                            Name = "Sue Mashmellow"
                        });
                });

            modelBuilder.Entity("ConfArch.Data.Entities.Conference", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Conferences");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Location = "Salt Lake City",
                            Name = "Pluralsight Live",
                            Start = new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            Location = "London",
                            Name = "Pluralsight Live",
                            Start = new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ConfArch.Data.Entities.Proposal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<long>("ConferenceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Proposals");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Approved = false,
                            ConferenceId = 1L,
                            Speaker = "Roland Guijt",
                            Title = "Authentication and Authorization in ASP.NET Core"
                        },
                        new
                        {
                            Id = 2L,
                            Approved = false,
                            ConferenceId = 2L,
                            Speaker = "Cindy Reynolds",
                            Title = "Authentication and Authorization in ASP.NET Core"
                        },
                        new
                        {
                            Id = 3L,
                            Approved = false,
                            ConferenceId = 2L,
                            Speaker = "Heather Lipens",
                            Title = "ASP.NET Core TagHelpers"
                        });
                });

            modelBuilder.Entity("ConfArch.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FavoriteColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConfArch.Data.Entities.Attendee", b =>
                {
                    b.HasOne("ConfArch.Data.Entities.Conference", "Conference")
                        .WithMany("Attendees")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");
                });

            modelBuilder.Entity("ConfArch.Data.Entities.Proposal", b =>
                {
                    b.HasOne("ConfArch.Data.Entities.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");
                });

            modelBuilder.Entity("ConfArch.Data.Entities.Conference", b =>
                {
                    b.Navigation("Attendees");
                });
#pragma warning restore 612, 618
        }
    }
}
