using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class saltModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "UsersDB",
                type: "RAW(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDBRankDB");

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "UsersDB",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "RAW(2000)");
        }
    }
}
