using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bkrnomefantasia = table.Column<string>(name: "bkr_nomefantasia", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    bkrrazaosocial = table.Column<string>(name: "bkr_razaosocial", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    bkrcnpj = table.Column<string>(name: "bkr_cnpj", type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIdUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIdUserLastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bkr_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_sector",
                columns: table => new
                {
                    sctId = table.Column<Guid>(name: "sct_Id", type: "uniqueidentifier", nullable: false, comment: "pk table"),
                    sctname = table.Column<string>(name: "sct_name", type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "sector name"),
                    sctDCreated = table.Column<DateTime>(name: "sct_DCreated", type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIdUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIdUserLastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sct_id", x => x.sctId);
                },
                comment: "abbreviation: sct\r\nDescription: table sector");

            migrationBuilder.CreateTable(
                name: "tb_wallet",
                columns: table => new
                {
                    walId = table.Column<Guid>(name: "wal_Id", type: "uniqueidentifier", nullable: false, comment: "PK table"),
                    walname = table.Column<string>(name: "wal_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Name wallet"),
                    walnew = table.Column<string>(name: "wal_new", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("wal_Id", x => x.walId);
                },
                comment: "abbreviation:  wal\r\nDescription: tables wallet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "tb_sector");

            migrationBuilder.DropTable(
                name: "tb_wallet");
        }
    }
}
