﻿// <auto-generated />
using System;
using InnoEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InnoEvents.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230331100333_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("InnoEvents.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("InnoEvents.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InnoEvents.Models.UserEvent", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("InnoEvents.Models.UserEvent", b =>
                {
                    b.HasOne("InnoEvents.Models.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnoEvents.Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InnoEvents.Models.Event", b =>
                {
                    b.Navigation("EventUsers");
                });

            modelBuilder.Entity("InnoEvents.Models.User", b =>
                {
                    b.Navigation("UserEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
