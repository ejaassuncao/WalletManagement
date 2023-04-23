using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_broker",
                columns: table => new
                {
                    bkrid = table.Column<Guid>(name: "bkr_id", type: "uniqueidentifier", nullable: false),
                    bkrfantasyname = table.Column<string>(name: "bkr_fantasy_name", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    bkrcorporatename = table.Column<string>(name: "bkr_corporate_name", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    bkrcnpj = table.Column<string>(name: "bkr_cnpj", type: "nvarchar(18)", maxLength: 18, nullable: false),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_broker", x => x.bkrid);
                },
                comment: "sufix: bkr");

            migrationBuilder.CreateTable(
                name: "tb_sector",
                columns: table => new
                {
                    sctid = table.Column<Guid>(name: "sct_id", type: "uniqueidentifier", nullable: false),
                    sctname = table.Column<string>(name: "sct_name", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sector", x => x.sctid);
                },
                comment: "sufix: sct");

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    usuid = table.Column<Guid>(name: "usu_id", type: "uniqueidentifier", nullable: false),
                    usulogin = table.Column<string>(name: "usu_login", type: "nvarchar(60)", maxLength: 60, nullable: false),
                    usupassword = table.Column<string>(name: "usu_password", type: "nvarchar(255)", maxLength: 255, nullable: false),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.usuid);
                },
                comment: "sufix: usu");

            migrationBuilder.CreateTable(
                name: "tb_company",
                columns: table => new
                {
                    cpyid = table.Column<Guid>(name: "cpy_id", type: "uniqueidentifier", nullable: false),
                    cpyname = table.Column<string>(name: "cpy_name", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    cpycnpj = table.Column<string>(name: "cpy_cnpj", type: "nvarchar(18)", maxLength: 18, nullable: false),
                    sctid = table.Column<Guid>(name: "sct_id", type: "uniqueidentifier", nullable: true),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_company", x => x.cpyid);
                    table.ForeignKey(
                        name: "FK_tb_company_tb_sector_sct_id",
                        column: x => x.sctid,
                        principalTable: "tb_sector",
                        principalColumn: "sct_id");
                },
                comment: "sufix: cpy");

            migrationBuilder.CreateTable(
                name: "tb_wallet",
                columns: table => new
                {
                    walId = table.Column<Guid>(name: "wal_Id", type: "uniqueidentifier", nullable: false),
                    walname = table.Column<string>(name: "wal_name", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    usuid = table.Column<Guid>(name: "usu_id", type: "uniqueidentifier", nullable: true),
                    bkrid = table.Column<Guid>(name: "bkr_id", type: "uniqueidentifier", nullable: true),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_wallet", x => x.walId);
                    table.ForeignKey(
                        name: "FK_tb_wallet_tb_broker_bkr_id",
                        column: x => x.bkrid,
                        principalTable: "tb_broker",
                        principalColumn: "bkr_id");
                    table.ForeignKey(
                        name: "FK_tb_wallet_tb_user_usu_id",
                        column: x => x.usuid,
                        principalTable: "tb_user",
                        principalColumn: "usu_id");
                },
                comment: "sufix: wal");

            migrationBuilder.CreateTable(
                name: "tb_actives",
                columns: table => new
                {
                    actid = table.Column<Guid>(name: "act_id", type: "uniqueidentifier", nullable: false),
                    actticker = table.Column<string>(name: "act_ticker", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    actprice = table.Column<decimal>(name: "act_price", type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    actcategory = table.Column<int>(name: "act_category", type: "int", nullable: false),
                    cpyid = table.Column<Guid>(name: "cpy_id", type: "uniqueidentifier", nullable: true),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_actives", x => x.actid);
                    table.ForeignKey(
                        name: "FK_tb_actives_tb_company_cpy_id",
                        column: x => x.cpyid,
                        principalTable: "tb_company",
                        principalColumn: "cpy_id");
                },
                comment: "sufix: act");

            migrationBuilder.CreateTable(
                name: "tb_actives_company",
                columns: table => new
                {
                    aocid = table.Column<Guid>(name: "aoc_id", type: "uniqueidentifier", nullable: false),
                    aocamount = table.Column<decimal>(name: "aoc_amount", type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    aocunitcost = table.Column<decimal>(name: "aoc_unit_cost", type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    aocdateoperation = table.Column<DateTime>(name: "aoc_date_operation", type: "datetime2", nullable: false),
                    aocoperation = table.Column<int>(name: "aoc_operation", type: "int", nullable: false),
                    usuid = table.Column<Guid>(name: "usu_id", type: "uniqueidentifier", nullable: true),
                    bkrid = table.Column<Guid>(name: "bkr_id", type: "uniqueidentifier", nullable: true),
                    walId = table.Column<Guid>(name: "wal_Id", type: "uniqueidentifier", nullable: true),
                    actid = table.Column<Guid>(name: "act_id", type: "uniqueidentifier", nullable: true),
                    enabled = table.Column<byte>(type: "tinyint", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<Guid>(name: "user_created", type: "uniqueidentifier", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<Guid>(name: "user_last_update", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_actives_company", x => x.aocid);
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_actives_act_id",
                        column: x => x.actid,
                        principalTable: "tb_actives",
                        principalColumn: "act_id");
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_broker_bkr_id",
                        column: x => x.bkrid,
                        principalTable: "tb_broker",
                        principalColumn: "bkr_id");
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_user_usu_id",
                        column: x => x.usuid,
                        principalTable: "tb_user",
                        principalColumn: "usu_id");
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_wallet_wal_Id",
                        column: x => x.walId,
                        principalTable: "tb_wallet",
                        principalColumn: "wal_Id");
                },
                comment: "sufix: aoc");

            migrationBuilder.InsertData(
                table: "tb_broker",
                columns: new[] { "bkr_id", "bkr_cnpj", "bkr_corporate_name", "d_created", "enabled", "bkr_fantasy_name", "last_update", "user_created", "user_last_update" },
                values: new object[] { new Guid("1a7e5b4e-15b2-4a03-81d4-1f45619d5d1a"), "48.537.525/0001-01", "Itau", new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1070), (byte)1, "Itau investimentos", null, new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null });

            migrationBuilder.InsertData(
                table: "tb_sector",
                columns: new[] { "sct_id", "d_created", "enabled", "last_update", "sct_name", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("aeadc5b3-b681-4292-843e-84a0406163d4"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1048), (byte)1, null, "Varejo", new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null },
                    { new Guid("af835580-fe43-48b3-ac7d-c601e2a61c70"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1050), (byte)1, null, "Financeiro", new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "usu_id", "d_created", "enabled", "last_update", "usu_login", "usu_password", "user_created", "user_last_update" },
                values: new object[] { new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(754), (byte)1, null, "elton", "123456", new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null });

            migrationBuilder.InsertData(
                table: "tb_company",
                columns: new[] { "cpy_id", "cpy_cnpj", "d_created", "enabled", "last_update", "cpy_name", "sct_id", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("04996bb3-502b-41ae-9972-afe76a69f6a2"), "48.537.523/0001-01", new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1124), (byte)1, null, "Banco do Brasil", new Guid("af835580-fe43-48b3-ac7d-c601e2a61c70"), new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null },
                    { new Guid("5de9bdc7-2701-4485-97b0-e0844c86ea68"), "48.537.555/0001-01", new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1121), (byte)1, null, "Magazine Luiza", new Guid("aeadc5b3-b681-4292-843e-84a0406163d4"), new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_wallet",
                columns: new[] { "wal_Id", "bkr_id", "d_created", "enabled", "last_update", "wal_name", "usu_id", "user_created", "user_last_update" },
                values: new object[] { new Guid("89856041-3911-44aa-bffd-3a28a4af5464"), new Guid("1a7e5b4e-15b2-4a03-81d4-1f45619d5d1a"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1085), (byte)1, null, "Minha Carteira", new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "tb_actives",
                columns: new[] { "act_id", "act_category", "cpy_id", "d_created", "enabled", "last_update", "act_price", "act_ticker", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("078602da-0a77-42f0-a6bc-1a2db3be6cf1"), 0, new Guid("5de9bdc7-2701-4485-97b0-e0844c86ea68"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1136), (byte)1, null, 10.8m, "MGLU3", new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null },
                    { new Guid("cc22ceb3-cf16-4e08-aafc-d732b8f42317"), 0, new Guid("04996bb3-502b-41ae-9972-afe76a69f6a2"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1142), (byte)1, null, 40.7m, "BBAS3", new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_actives_company",
                columns: new[] { "aoc_id", "act_id", "aoc_amount", "bkr_id", "aoc_date_operation", "d_created", "enabled", "last_update", "aoc_operation", "aoc_unit_cost", "user_created", "usu_id", "user_last_update", "wal_Id" },
                values: new object[,]
                {
                    { new Guid("00ebd4c8-ca91-4858-9b9d-84d524feafe9"), new Guid("078602da-0a77-42f0-a6bc-1a2db3be6cf1"), 50m, new Guid("1a7e5b4e-15b2-4a03-81d4-1f45619d5d1a"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1157), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1158), (byte)1, null, 1, 22.5m, new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null, new Guid("89856041-3911-44aa-bffd-3a28a4af5464") },
                    { new Guid("6f1fb3f9-3a95-4a94-b047-5101cb3b12fa"), new Guid("cc22ceb3-cf16-4e08-aafc-d732b8f42317"), 200.121m, new Guid("1a7e5b4e-15b2-4a03-81d4-1f45619d5d1a"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1167), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1167), (byte)1, null, 1, 43.5m, new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null, new Guid("89856041-3911-44aa-bffd-3a28a4af5464") },
                    { new Guid("7d3b139b-3022-4ea0-b3af-fd5b744f6e35"), new Guid("cc22ceb3-cf16-4e08-aafc-d732b8f42317"), 200m, new Guid("1a7e5b4e-15b2-4a03-81d4-1f45619d5d1a"), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1164), new DateTime(2023, 4, 22, 21, 53, 16, 940, DateTimeKind.Local).AddTicks(1164), (byte)1, null, 1, 43.5m, new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), new Guid("0b266425-061d-4705-a3b7-f77a2892e85a"), null, new Guid("89856041-3911-44aa-bffd-3a28a4af5464") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_cpy_id",
                table: "tb_actives",
                column: "cpy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_act_id",
                table: "tb_actives_company",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_bkr_id",
                table: "tb_actives_company",
                column: "bkr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_usu_id",
                table: "tb_actives_company",
                column: "usu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_wal_Id",
                table: "tb_actives_company",
                column: "wal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_company_sct_id",
                table: "tb_company",
                column: "sct_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_wallet_bkr_id",
                table: "tb_wallet",
                column: "bkr_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_wallet_usu_id",
                table: "tb_wallet",
                column: "usu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_actives_company");

            migrationBuilder.DropTable(
                name: "tb_actives");

            migrationBuilder.DropTable(
                name: "tb_wallet");

            migrationBuilder.DropTable(
                name: "tb_company");

            migrationBuilder.DropTable(
                name: "tb_broker");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_sector");
        }
    }
}
