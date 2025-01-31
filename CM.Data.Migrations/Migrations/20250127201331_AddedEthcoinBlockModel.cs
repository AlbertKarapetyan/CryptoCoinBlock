using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CM.Data.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedEthcoinBlockModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "unconfirmed_tx_count",
                table: "litecoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "peer_count",
                table: "litecoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "unconfirmed_tx_count",
                table: "dashcoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "peer_count",
                table: "dashcoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "unconfirmed_tx_count",
                table: "bitcoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "peer_count",
                table: "bitcoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "ethcoin_blocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    high_gas_price = table.Column<long>(type: "bigint", nullable: false),
                    medium_gas_price = table.Column<long>(type: "bigint", nullable: false),
                    low_gas_price = table.Column<long>(type: "bigint", nullable: false),
                    high_priority_fee = table.Column<long>(type: "bigint", nullable: false),
                    medium_priority_fee = table.Column<long>(type: "bigint", nullable: false),
                    low_priority_fee = table.Column<long>(type: "bigint", nullable: false),
                    base_fee = table.Column<long>(type: "bigint", nullable: false),
                    block_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    block_height = table.Column<long>(type: "bigint", nullable: false),
                    block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    block_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latest_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    previous_block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    previous_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    peer_count = table.Column<short>(type: "smallint", nullable: false),
                    unconfirmed_tx_count = table.Column<short>(type: "smallint", nullable: false),
                    last_fork_height = table.Column<long>(type: "bigint", nullable: false),
                    last_fork_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    is_test = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ethcoin_blocks", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ethcoin_blocks_created_at",
                table: "ethcoin_blocks",
                column: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ethcoin_blocks");

            migrationBuilder.AlterColumn<int>(
                name: "unconfirmed_tx_count",
                table: "litecoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "peer_count",
                table: "litecoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "unconfirmed_tx_count",
                table: "dashcoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "peer_count",
                table: "dashcoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "unconfirmed_tx_count",
                table: "bitcoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "peer_count",
                table: "bitcoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
