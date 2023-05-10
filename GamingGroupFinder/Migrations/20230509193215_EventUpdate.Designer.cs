﻿// <auto-generated />
using System;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace _410project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230509193215_EventUpdate")]
    partial class EventUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventDBUserDB", b =>
                {
                    b.Property<int>("EventsAttendingEventDBId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsersAttendingUserDBId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EventsAttendingEventDBId", "UsersAttendingUserDBId");

                    b.HasIndex("UsersAttendingUserDBId");

                    b.ToTable("EventDBUserDB");
                });

            modelBuilder.Entity("GameDBPlatformDB", b =>
                {
                    b.Property<int>("GamesGameDBId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PlatformsPlatformDBId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("GamesGameDBId", "PlatformsPlatformDBId");

                    b.HasIndex("PlatformsPlatformDBId");

                    b.ToTable("GameDBPlatformDB");
                });

            modelBuilder.Entity("GameDBProfileDB", b =>
                {
                    b.Property<int>("GamesGameDBId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProfilesProfileDBId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("GamesGameDBId", "ProfilesProfileDBId");

                    b.HasIndex("ProfilesProfileDBId");

                    b.ToTable("GameDBProfileDB");
                });

            modelBuilder.Entity("GameDBRankDB", b =>
                {
                    b.Property<int>("GamesGameDBId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RanksRankDBId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("GamesGameDBId", "RanksRankDBId");

                    b.HasIndex("RanksRankDBId");

                    b.ToTable("GameDBRankDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.EventDB", b =>
                {
                    b.Property<int>("EventDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventDBId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("GameId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EventDBId");

                    b.HasIndex("GameId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PlatformId");

                    b.ToTable("EventsDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.GameDB", b =>
                {
                    b.Property<int>("GameDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameDBId"));

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("GameDBId");

                    b.ToTable("GamesDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.InterestDB", b =>
                {
                    b.Property<int>("InterestDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestDBId"));

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("InterestDBId");

                    b.ToTable("InterestsDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.MessageDB", b =>
                {
                    b.Property<int>("MessageDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageDBId"));

                    b.Property<bool>("IsSeen")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("SenderId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("MessageDBId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("MessagesDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.PlatformDB", b =>
                {
                    b.Property<int>("PlatformDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformDBId"));

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PlatformDBId");

                    b.ToTable("PlatformsDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.ProfileDB", b =>
                {
                    b.Property<int>("ProfileDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileDBId"));

                    b.Property<int>("Age")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Bio")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Pronouns")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ProfileDBId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProfilesDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.RankDB", b =>
                {
                    b.Property<int>("RankDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankDBId"));

                    b.Property<string>("RankName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("RankValue")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("RankDBId");

                    b.ToTable("RanksDB");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.UserDB", b =>
                {
                    b.Property<int>("UserDBId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserDBId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserDBId");

                    b.ToTable("UsersDB");
                });

            modelBuilder.Entity("InterestDBProfileDB", b =>
                {
                    b.Property<int>("InterestsInterestDBId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProfilesProfileDBId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("InterestsInterestDBId", "ProfilesProfileDBId");

                    b.HasIndex("ProfilesProfileDBId");

                    b.ToTable("InterestDBProfileDB");
                });

            modelBuilder.Entity("PlatformDBProfileDB", b =>
                {
                    b.Property<int>("PlatformsPlatformDBId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProfilesProfileDBId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PlatformsPlatformDBId", "ProfilesProfileDBId");

                    b.HasIndex("ProfilesProfileDBId");

                    b.ToTable("PlatformDBProfileDB");
                });

            modelBuilder.Entity("EventDBUserDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.EventDB", null)
                        .WithMany()
                        .HasForeignKey("EventsAttendingEventDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.UserDB", null)
                        .WithMany()
                        .HasForeignKey("UsersAttendingUserDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameDBPlatformDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.GameDB", null)
                        .WithMany()
                        .HasForeignKey("GamesGameDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.PlatformDB", null)
                        .WithMany()
                        .HasForeignKey("PlatformsPlatformDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameDBProfileDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.GameDB", null)
                        .WithMany()
                        .HasForeignKey("GamesGameDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.ProfileDB", null)
                        .WithMany()
                        .HasForeignKey("ProfilesProfileDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameDBRankDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.GameDB", null)
                        .WithMany()
                        .HasForeignKey("GamesGameDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.RankDB", null)
                        .WithMany()
                        .HasForeignKey("RanksRankDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.EventDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.GameDB", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.UserDB", "Owner")
                        .WithMany("EventsOwned")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.PlatformDB", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Owner");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.MessageDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.UserDB", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.UserDB", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.ProfileDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.UserDB", "User")
                        .WithOne("Profile")
                        .HasForeignKey("GamingGroupFinderGUI.Models.ProfileDB", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InterestDBProfileDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.InterestDB", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.ProfileDB", null)
                        .WithMany()
                        .HasForeignKey("ProfilesProfileDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlatformDBProfileDB", b =>
                {
                    b.HasOne("GamingGroupFinderGUI.Models.PlatformDB", null)
                        .WithMany()
                        .HasForeignKey("PlatformsPlatformDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderGUI.Models.ProfileDB", null)
                        .WithMany()
                        .HasForeignKey("ProfilesProfileDBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingGroupFinderGUI.Models.UserDB", b =>
                {
                    b.Navigation("EventsOwned");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
