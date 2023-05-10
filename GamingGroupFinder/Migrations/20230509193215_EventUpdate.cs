using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class EventUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsDB_RanksDB_MaxRankId",
                table: "EventsDB");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsDB_RanksDB_MinRankId",
                table: "EventsDB");

            migrationBuilder.DropTable(
                name: "GamesDBRanksDB");

            migrationBuilder.DropIndex(
                name: "IX_EventsDB_MaxRankId",
                table: "EventsDB");

            migrationBuilder.DropIndex(
                name: "IX_EventsDB_MinRankId",
                table: "EventsDB");

            migrationBuilder.DropColumn(
                name: "MaxRankId",
                table: "EventsDB");

            migrationBuilder.DropColumn(
                name: "MinRankId",
                table: "EventsDB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxRankId",
                table: "EventsDB",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinRankId",
                table: "EventsDB",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GamesDBRanksDB",
                columns: table => new
                {
                    GameDBId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RankDBId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GamesDBRanksDB_GamesDB_GameDBId",
                        column: x => x.GameDBId,
                        principalTable: "GamesDB",
                        principalColumn: "GameDBId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesDBRanksDB_RanksDB_RankDBId",
                        column: x => x.RankDBId,
                        principalTable: "RanksDB",
                        principalColumn: "RankDBId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsDB_MaxRankId",
                table: "EventsDB",
                column: "MaxRankId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDB_MinRankId",
                table: "EventsDB",
                column: "MinRankId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesDBRanksDB_GameDBId",
                table: "GamesDBRanksDB",
                column: "GameDBId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesDBRanksDB_RankDBId",
                table: "GamesDBRanksDB",
                column: "RankDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsDB_RanksDB_MaxRankId",
                table: "EventsDB",
                column: "MaxRankId",
                principalTable: "RanksDB",
                principalColumn: "RankDBId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsDB_RanksDB_MinRankId",
                table: "EventsDB",
                column: "MinRankId",
                principalTable: "RanksDB",
                principalColumn: "RankDBId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
