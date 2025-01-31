using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CM.Data.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "ethcoin_blocks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "peer_count",
                table: "ethcoin_blocks",
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

            migrationBuilder.CreateTable(
                name: "cypher_blocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    high_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    medium_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    low_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    block_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    block_height = table.Column<long>(type: "bigint", nullable: false),
                    block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    block_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latest_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    previous_block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    previous_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    peer_count = table.Column<int>(type: "integer", nullable: false),
                    unconfirmed_tx_count = table.Column<int>(type: "integer", nullable: false),
                    last_fork_height = table.Column<long>(type: "bigint", nullable: false),
                    last_fork_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    is_test = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cypher_blocks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dogecoin_blocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    high_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    medium_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    low_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    block_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    block_height = table.Column<long>(type: "bigint", nullable: false),
                    block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    block_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latest_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    previous_block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    previous_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    peer_count = table.Column<int>(type: "integer", nullable: false),
                    unconfirmed_tx_count = table.Column<int>(type: "integer", nullable: false),
                    last_fork_height = table.Column<long>(type: "bigint", nullable: false),
                    last_fork_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    is_test = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogecoin_blocks", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cypher_blocks_created_at",
                table: "cypher_blocks",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_dogecoin_blocks_created_at",
                table: "dogecoin_blocks",
                column: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cypher_blocks");

            migrationBuilder.DropTable(
                name: "dogecoin_blocks");

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
                table: "ethcoin_blocks",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<short>(
                name: "peer_count",
                table: "ethcoin_blocks",
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
        }
    }
}
