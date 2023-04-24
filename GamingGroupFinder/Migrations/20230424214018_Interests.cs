using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _410project.Migrations
{
    /// <inheritdoc />
    public partial class Interests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestDBProfileDB_InterestDB_InterestsInterestDBId",
                table: "InterestDBProfileDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestDB",
                table: "InterestDB");

            migrationBuilder.RenameTable(
                name: "InterestDB",
                newName: "InterestsDB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestsDB",
                table: "InterestsDB",
                column: "InterestDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestDBProfileDB_InterestsDB_InterestsInterestDBId",
                table: "InterestDBProfileDB",
                column: "InterestsInterestDBId",
                principalTable: "InterestsDB",
                principalColumn: "InterestDBId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestDBProfileDB_InterestsDB_InterestsInterestDBId",
                table: "InterestDBProfileDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestsDB",
                table: "InterestsDB");

            migrationBuilder.RenameTable(
                name: "InterestsDB",
                newName: "InterestDB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestDB",
                table: "InterestDB",
                column: "InterestDBId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestDBProfileDB_InterestDB_InterestsInterestDBId",
                table: "InterestDBProfileDB",
                column: "InterestsInterestDBId",
                principalTable: "InterestDB",
                principalColumn: "InterestDBId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
