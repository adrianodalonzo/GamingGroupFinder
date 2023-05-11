using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamesDB",
                columns: table => new
                {
                    GameDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    GameName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesDB", x => x.GameDBId);
                });

            migrationBuilder.CreateTable(
                name: "InterestsDB",
                columns: table => new
                {
                    InterestDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InterestName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsDB", x => x.InterestDBId);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsDB",
                columns: table => new
                {
                    PlatformDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PlatformName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsDB", x => x.PlatformDBId);
                });

            migrationBuilder.CreateTable(
                name: "RanksDB",
                columns: table => new
                {
                    RankDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RankValue = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RankName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RanksDB", x => x.RankDBId);
                });

            migrationBuilder.CreateTable(
                name: "UsersDB",
                columns: table => new
                {
                    UserDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salt = table.Column<byte[]>(type: "RAW(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDB", x => x.UserDBId);
                });

            migrationBuilder.CreateTable(
                name: "GameDBPlatformDB",
                columns: table => new
                {
                    GamesGameDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PlatformsPlatformDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDBPlatformDB", x => new { x.GamesGameDBId, x.PlatformsPlatformDBId });
                    table.ForeignKey(
                        name: "FK_GameDBPlatformDB_GamesDB_GamesGameDBId",
                        column: x => x.GamesGameDBId,
                        principalTable: "GamesDB",
                        principalColumn: "GameDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDBPlatformDB_PlatformsDB_PlatformsPlatformDBId",
                        column: x => x.PlatformsPlatformDBId,
                        principalTable: "PlatformsDB",
                        principalColumn: "PlatformDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDBRankDB",
                columns: table => new
                {
                    GamesGameDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RanksRankDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDBRankDB", x => new { x.GamesGameDBId, x.RanksRankDBId });
                    table.ForeignKey(
                        name: "FK_GameDBRankDB_GamesDB_GamesGameDBId",
                        column: x => x.GamesGameDBId,
                        principalTable: "GamesDB",
                        principalColumn: "GameDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDBRankDB_RanksDB_RanksRankDBId",
                        column: x => x.RanksRankDBId,
                        principalTable: "RanksDB",
                        principalColumn: "RankDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsDB",
                columns: table => new
                {
                    EventDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    OwnerId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Time = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GameId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PlatformId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsDB", x => x.EventDBId);
                    table.ForeignKey(
                        name: "FK_EventsDB_GamesDB_GameId",
                        column: x => x.GameId,
                        principalTable: "GamesDB",
                        principalColumn: "GameDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsDB_PlatformsDB_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "PlatformsDB",
                        principalColumn: "PlatformDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsDB_UsersDB_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "UsersDB",
                        principalColumn: "UserDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessagesDB",
                columns: table => new
                {
                    MessageDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SenderId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReceiverId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Time = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MessageText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsSeen = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesDB", x => x.MessageDBId);
                    table.ForeignKey(
                        name: "FK_MessagesDB_UsersDB_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "UsersDB",
                        principalColumn: "UserDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessagesDB_UsersDB_SenderId",
                        column: x => x.SenderId,
                        principalTable: "UsersDB",
                        principalColumn: "UserDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilesDB",
                columns: table => new
                {
                    ProfileDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Pronouns = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Bio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilesDB", x => x.ProfileDBId);
                    table.ForeignKey(
                        name: "FK_ProfilesDB_UsersDB_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersDB",
                        principalColumn: "UserDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDBUserDB",
                columns: table => new
                {
                    EventsAttendingEventDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsersAttendingUserDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDBUserDB", x => new { x.EventsAttendingEventDBId, x.UsersAttendingUserDBId });
                    table.ForeignKey(
                        name: "FK_EventDBUserDB_EventsDB_EventsAttendingEventDBId",
                        column: x => x.EventsAttendingEventDBId,
                        principalTable: "EventsDB",
                        principalColumn: "EventDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDBUserDB_UsersDB_UsersAttendingUserDBId",
                        column: x => x.UsersAttendingUserDBId,
                        principalTable: "UsersDB",
                        principalColumn: "UserDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDBProfileDB",
                columns: table => new
                {
                    GamesGameDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProfilesProfileDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDBProfileDB", x => new { x.GamesGameDBId, x.ProfilesProfileDBId });
                    table.ForeignKey(
                        name: "FK_GameDBProfileDB_GamesDB_GamesGameDBId",
                        column: x => x.GamesGameDBId,
                        principalTable: "GamesDB",
                        principalColumn: "GameDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDBProfileDB_ProfilesDB_ProfilesProfileDBId",
                        column: x => x.ProfilesProfileDBId,
                        principalTable: "ProfilesDB",
                        principalColumn: "ProfileDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestDBProfileDB",
                columns: table => new
                {
                    InterestsInterestDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProfilesProfileDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestDBProfileDB", x => new { x.InterestsInterestDBId, x.ProfilesProfileDBId });
                    table.ForeignKey(
                        name: "FK_InterestDBProfileDB_InterestsDB_InterestsInterestDBId",
                        column: x => x.InterestsInterestDBId,
                        principalTable: "InterestsDB",
                        principalColumn: "InterestDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestDBProfileDB_ProfilesDB_ProfilesProfileDBId",
                        column: x => x.ProfilesProfileDBId,
                        principalTable: "ProfilesDB",
                        principalColumn: "ProfileDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDBProfileDB",
                columns: table => new
                {
                    PlatformsPlatformDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProfilesProfileDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDBProfileDB", x => new { x.PlatformsPlatformDBId, x.ProfilesProfileDBId });
                    table.ForeignKey(
                        name: "FK_PlatformDBProfileDB_PlatformsDB_PlatformsPlatformDBId",
                        column: x => x.PlatformsPlatformDBId,
                        principalTable: "PlatformsDB",
                        principalColumn: "PlatformDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformDBProfileDB_ProfilesDB_ProfilesProfileDBId",
                        column: x => x.ProfilesProfileDBId,
                        principalTable: "ProfilesDB",
                        principalColumn: "ProfileDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDBUserDB_UsersAttendingUserDBId",
                table: "EventDBUserDB",
                column: "UsersAttendingUserDBId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDB_GameId",
                table: "EventsDB",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDB_OwnerId",
                table: "EventsDB",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDB_PlatformId",
                table: "EventsDB",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDBPlatformDB_PlatformsPlatformDBId",
                table: "GameDBPlatformDB",
                column: "PlatformsPlatformDBId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDBProfileDB_ProfilesProfileDBId",
                table: "GameDBProfileDB",
                column: "ProfilesProfileDBId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDBRankDB_RanksRankDBId",
                table: "GameDBRankDB",
                column: "RanksRankDBId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestDBProfileDB_ProfilesProfileDBId",
                table: "InterestDBProfileDB",
                column: "ProfilesProfileDBId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesDB_ReceiverId",
                table: "MessagesDB",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesDB_SenderId",
                table: "MessagesDB",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDBProfileDB_ProfilesProfileDBId",
                table: "PlatformDBProfileDB",
                column: "ProfilesProfileDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesDB_UserId",
                table: "ProfilesDB",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDBUserDB");

            migrationBuilder.DropTable(
                name: "GameDBPlatformDB");

            migrationBuilder.DropTable(
                name: "GameDBProfileDB");

            migrationBuilder.DropTable(
                name: "GameDBRankDB");

            migrationBuilder.DropTable(
                name: "InterestDBProfileDB");

            migrationBuilder.DropTable(
                name: "MessagesDB");

            migrationBuilder.DropTable(
                name: "PlatformDBProfileDB");

            migrationBuilder.DropTable(
                name: "EventsDB");

            migrationBuilder.DropTable(
                name: "RanksDB");

            migrationBuilder.DropTable(
                name: "InterestsDB");

            migrationBuilder.DropTable(
                name: "ProfilesDB");

            migrationBuilder.DropTable(
                name: "GamesDB");

            migrationBuilder.DropTable(
                name: "PlatformsDB");

            migrationBuilder.DropTable(
                name: "UsersDB");
        }
    }
}
