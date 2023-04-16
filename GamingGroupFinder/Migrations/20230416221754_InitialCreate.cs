using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Username = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salt = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProfileUsername = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_Profile_ProfileUsername",
                        column: x => x.ProfileUsername,
                        principalTable: "Profile",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SenderUsername = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ReceiverUsername = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Time = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MessageText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsSeen = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverUsername",
                        column: x => x.ReceiverUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderUsername",
                        column: x => x.SenderUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverUsername",
                table: "Messages",
                column: "ReceiverUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUsername",
                table: "Messages",
                column: "SenderUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileUsername",
                table: "Users",
                column: "ProfileUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
