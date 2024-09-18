using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AssetTickerUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Assets_Ticker",
                table: "Assets",
                column: "Ticker",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Assets_Ticker",
                table: "Assets");
        }
    }
}
