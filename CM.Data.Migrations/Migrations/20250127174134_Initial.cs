using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CM.Data.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bitcoin_blocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    block_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    block_height = table.Column<long>(type: "bigint", nullable: false),
                    block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    block_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latest_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    previous_block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    previous_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    peer_count = table.Column<int>(type: "integer", nullable: false),
                    unconfirmed_tx_count = table.Column<int>(type: "integer", nullable: false),
                    high_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    medium_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    low_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    last_fork_height = table.Column<long>(type: "bigint", nullable: false),
                    last_fork_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bitcoin_blocks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dashcoin_blocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    block_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    block_height = table.Column<long>(type: "bigint", nullable: false),
                    block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    block_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latest_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    previous_block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    previous_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    peer_count = table.Column<int>(type: "integer", nullable: false),
                    unconfirmed_tx_count = table.Column<int>(type: "integer", nullable: false),
                    high_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    medium_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    low_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    last_fork_height = table.Column<long>(type: "bigint", nullable: false),
                    last_fork_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashcoin_blocks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "litecoin_blocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    block_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    block_height = table.Column<long>(type: "bigint", nullable: false),
                    block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    block_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latest_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    previous_block_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    previous_block_url = table.Column<string>(type: "character varying(2083)", maxLength: 2083, nullable: false),
                    peer_count = table.Column<int>(type: "integer", nullable: false),
                    unconfirmed_tx_count = table.Column<int>(type: "integer", nullable: false),
                    high_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    medium_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    low_fee_per_kb = table.Column<int>(type: "integer", nullable: false),
                    last_fork_height = table.Column<long>(type: "bigint", nullable: false),
                    last_fork_hash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_litecoin_blocks", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bitcoin_blocks_created_at",
                table: "bitcoin_blocks",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_dashcoin_blocks_created_at",
                table: "dashcoin_blocks",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_litecoin_blocks_created_at",
                table: "litecoin_blocks",
                column: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bitcoin_blocks");

            migrationBuilder.DropTable(
                name: "dashcoin_blocks");

            migrationBuilder.DropTable(
                name: "litecoin_blocks");
        }
    }
}
