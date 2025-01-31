using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.Data.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsTestfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_test",
                table: "litecoin_blocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_test",
                table: "dashcoin_blocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_test",
                table: "bitcoin_blocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_test",
                table: "litecoin_blocks");

            migrationBuilder.DropColumn(
                name: "is_test",
                table: "dashcoin_blocks");

            migrationBuilder.DropColumn(
                name: "is_test",
                table: "bitcoin_blocks");
        }
    }
}
