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
    [Migration("20230420173930_UserEventAttendingOwned")]
    partial class UserEventAttendingOwned
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventUser", b =>
                {
                    b.Property<int>("EventsAttendingEventId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EventsAttendingEventId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<int>("GamesGameId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PlatformsPlatformId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("GamesGameId", "PlatformsPlatformId");

                    b.HasIndex("PlatformsPlatformId");

                    b.ToTable("GamePlatform");
                });

            modelBuilder.Entity("GameProfile", b =>
                {
                    b.Property<int>("GamesGameId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProfilesProfileId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("GamesGameId", "ProfilesProfileId");

                    b.HasIndex("ProfilesProfileId");

                    b.ToTable("GameProfile");
                });

            modelBuilder.Entity("GameRank", b =>
                {
                    b.Property<int>("GamesGameId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RanksRankId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("GamesGameId", "RanksRankId");

                    b.HasIndex("RanksRankId");

                    b.ToTable("GameRank");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("GameId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("MaxRankId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("MinRankId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EventId");

                    b.HasIndex("GameId");

                    b.HasIndex("MaxRankId");

                    b.HasIndex("MinRankId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("InterestId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

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

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformId"));

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"));

                    b.Property<int>("Age")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Pronouns")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankId"));

                    b.Property<string>("RankName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("RankValue")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("RankId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InterestProfile", b =>
                {
                    b.Property<int>("InterestsInterestId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProfilesProfileId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("InterestsInterestId", "ProfilesProfileId");

                    b.HasIndex("ProfilesProfileId");

                    b.ToTable("InterestProfile");
                });

            modelBuilder.Entity("PlatformProfile", b =>
                {
                    b.Property<int>("PlatformsPlatformId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProfilesProfileId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PlatformsPlatformId", "ProfilesProfileId");

                    b.HasIndex("ProfilesProfileId");

                    b.ToTable("PlatformProfile");
                });

            modelBuilder.Entity("EventUser", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsAttendingEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameProfile", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameRank", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Rank", null)
                        .WithMany()
                        .HasForeignKey("RanksRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Event", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Rank", "MaxRank")
                        .WithMany()
                        .HasForeignKey("MaxRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Rank", "MinRank")
                        .WithMany()
                        .HasForeignKey("MinRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.User", "User")
                        .WithMany("EventsOwned")
                        .HasForeignKey("UserId");

                    b.Navigation("Game");

                    b.Navigation("MaxRank");

                    b.Navigation("MinRank");

                    b.Navigation("Platform");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Message", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Profile", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("GamingGroupFinderDatabase.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InterestProfile", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlatformProfile", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsPlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.User", b =>
                {
                    b.Navigation("EventsOwned");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
