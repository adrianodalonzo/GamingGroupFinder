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
    [Migration("20230416221754_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("ReceiverUsername")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("SenderUsername")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverUsername");

                    b.HasIndex("SenderUsername");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Profile", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("Username");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ProfileUsername")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Username");

                    b.HasIndex("ProfileUsername");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.Message", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroupFinderDatabase.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("GamingGroupFinderDatabase.User", b =>
                {
                    b.HasOne("GamingGroupFinderDatabase.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
