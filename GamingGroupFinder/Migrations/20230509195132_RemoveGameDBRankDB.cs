using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGameDBRankDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesDBRanksDB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
