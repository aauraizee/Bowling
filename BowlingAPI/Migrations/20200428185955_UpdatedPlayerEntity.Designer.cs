﻿// <auto-generated />
using System;
using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BowlingAPI.Migrations
{
    [DbContext(typeof(BowlingContext))]
    [Migration("20200428185955_UpdatedPlayerEntity")]
    partial class UpdatedPlayerEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("BowlingAPI.Models.Frame", b =>
                {
                    b.Property<int>("FrameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeFlag")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("FrameId");

                    b.HasIndex("GameId");

                    b.ToTable("Frames");
                });

            modelBuilder.Entity("BowlingAPI.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalScore")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BowlingAPI.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentAverage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BowlingAPI.Models.Shot", b =>
                {
                    b.Property<int>("ShotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FrameId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSpareShot")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PinsHit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpareType")
                        .HasColumnType("TEXT");

                    b.Property<bool>("WasConverted")
                        .HasColumnType("INTEGER");

                    b.HasKey("ShotId");

                    b.HasIndex("FrameId");

                    b.ToTable("Shots");
                });

            modelBuilder.Entity("BowlingAPI.Models.Frame", b =>
                {
                    b.HasOne("BowlingAPI.Models.Game", "Game")
                        .WithMany("Frames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BowlingAPI.Models.Game", b =>
                {
                    b.HasOne("BowlingAPI.Models.Player", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BowlingAPI.Models.Shot", b =>
                {
                    b.HasOne("BowlingAPI.Models.Frame", "Frame")
                        .WithMany("Shots")
                        .HasForeignKey("FrameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}