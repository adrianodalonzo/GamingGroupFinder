using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class GameRanksBridgingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDBRankDB");

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
                name: "IX_GamesDBRanksDB_GameDBId",
                table: "GamesDBRanksDB",
                column: "GameDBId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesDBRanksDB_RankDBId",
                table: "GamesDBRanksDB",
                column: "RankDBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesDBRanksDB");

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

            migrationBuilder.CreateIndex(
                name: "IX_GameDBRankDB_RanksRankDBId",
                table: "GameDBRankDB",
                column: "RanksRankDBId");
        }
    }
}
