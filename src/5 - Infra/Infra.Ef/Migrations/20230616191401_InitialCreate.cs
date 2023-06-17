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
                    actticker = table.Column<string>(name: "act_ticker", type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Name Ticker"),
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
                values: new object[] { new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"), "48.537.525/0001-01", "Itau", new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7866), (byte)1, "Itau investimentos", null, new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null });

            migrationBuilder.InsertData(
                table: "tb_sector",
                columns: new[] { "sct_id", "d_created", "enabled", "last_update", "sct_name", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("42f99c91-c3a6-4e59-8473-5d443bcb58ce"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7843), (byte)1, null, "Eletrico", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null },
                    { new Guid("6ef7a2cf-9157-48ee-8fa9-e8a5a99f2946"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7842), (byte)1, null, "Financeiro", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null },
                    { new Guid("7c3c1968-a503-4c03-b8ee-9526bc2a339b"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7839), (byte)1, null, "Varejo", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "usu_id", "d_created", "enabled", "last_update", "usu_login", "usu_password", "user_created", "user_last_update" },
                values: new object[] { new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7528), (byte)1, null, "elton", "123456", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null });

            migrationBuilder.InsertData(
                table: "tb_company",
                columns: new[] { "cpy_id", "cpy_cnpj", "d_created", "enabled", "last_update", "cpy_name", "sct_id", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("180f672b-bf89-45a7-b31e-c6ed926679e2"), "48.566.523/0001-01", new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7907), (byte)1, null, "Taeesa transmissão Eletrica", new Guid("42f99c91-c3a6-4e59-8473-5d443bcb58ce"), new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null },
                    { new Guid("f12f8f13-bec9-4774-b9f2-6bcbbcd65039"), "48.537.523/0001-01", new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7906), (byte)1, null, "Banco do Brasil", new Guid("6ef7a2cf-9157-48ee-8fa9-e8a5a99f2946"), new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null },
                    { new Guid("fd4b5d91-8ad0-4323-96fe-8c1573a42b99"), "48.537.555/0001-01", new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7903), (byte)1, null, "Magazine Luiza", new Guid("7c3c1968-a503-4c03-b8ee-9526bc2a339b"), new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_wallet",
                columns: new[] { "wal_Id", "bkr_id", "d_created", "enabled", "last_update", "wal_name", "usu_id", "user_created", "user_last_update" },
                values: new object[] { new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da"), new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7883), (byte)1, null, "Minha Carteira", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "tb_actives",
                columns: new[] { "act_id", "act_category", "cpy_id", "d_created", "enabled", "last_update", "act_price", "act_ticker", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("1b0f4b1f-828c-4936-ab72-1122b3f5d7ab"), 0, new Guid("fd4b5d91-8ad0-4323-96fe-8c1573a42b99"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7925), (byte)1, null, 0m, "MGLU3", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null },
                    { new Guid("433853d2-c779-42a0-86c7-5022394ec58b"), 0, new Guid("f12f8f13-bec9-4774-b9f2-6bcbbcd65039"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7928), (byte)1, null, 0m, "BBAS3", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null },
                    { new Guid("d2aaeddb-aad5-402b-8cba-c1b5f87d41bf"), 0, new Guid("180f672b-bf89-45a7-b31e-c6ed926679e2"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7930), (byte)1, null, 0m, "TAEE3", new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_actives_company",
                columns: new[] { "aoc_id", "act_id", "aoc_amount", "bkr_id", "aoc_date_operation", "d_created", "enabled", "last_update", "aoc_operation", "aoc_unit_cost", "user_created", "usu_id", "user_last_update", "wal_Id" },
                values: new object[,]
                {
                    { new Guid("08a346ca-4f7c-4c75-8563-2573cdf55608"), new Guid("d2aaeddb-aad5-402b-8cba-c1b5f87d41bf"), 600m, new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7956), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7956), (byte)1, null, 0, 13.5m, new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null, new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da") },
                    { new Guid("15e159dd-990c-4f0a-ac5d-21e3975a609d"), new Guid("433853d2-c779-42a0-86c7-5022394ec58b"), 200m, new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7953), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7953), (byte)1, null, 0, 43.5m, new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null, new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da") },
                    { new Guid("87eb1def-1515-4020-9081-5f17b6475cdd"), new Guid("1b0f4b1f-828c-4936-ab72-1122b3f5d7ab"), 50m, new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7945), new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7946), (byte)1, null, 0, 22.5m, new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"), null, new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da") }
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
