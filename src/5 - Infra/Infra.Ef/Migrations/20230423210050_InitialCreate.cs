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
                values: new object[] { new Guid("918282dc-5ce2-4d1d-bf76-2430229c4a1b"), "48.537.525/0001-01", "Itau", new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2494), (byte)1, "Itau investimentos", null, new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null });

            migrationBuilder.InsertData(
                table: "tb_sector",
                columns: new[] { "sct_id", "d_created", "enabled", "last_update", "sct_name", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("529b0273-a393-4b42-9e1c-9b659f1d77fd"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2467), (byte)1, null, "Varejo", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null },
                    { new Guid("7276659e-7780-46b2-8479-4ff816e53950"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2471), (byte)1, null, "Eletrico", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null },
                    { new Guid("99daffc0-d045-4a31-8151-5865227dd317"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2470), (byte)1, null, "Financeiro", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "usu_id", "d_created", "enabled", "last_update", "usu_login", "usu_password", "user_created", "user_last_update" },
                values: new object[] { new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2004), (byte)1, null, "elton", "123456", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null });

            migrationBuilder.InsertData(
                table: "tb_company",
                columns: new[] { "cpy_id", "cpy_cnpj", "d_created", "enabled", "last_update", "cpy_name", "sct_id", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("a0b3920e-04f4-4254-9ae6-73a6d915c175"), "48.566.523/0001-01", new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2538), (byte)1, null, "Taeesa transmissão Eletrica", new Guid("7276659e-7780-46b2-8479-4ff816e53950"), new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null },
                    { new Guid("c7e5f1dd-1348-4da5-a256-f2cd8df0ff94"), "48.537.555/0001-01", new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2534), (byte)1, null, "Magazine Luiza", new Guid("529b0273-a393-4b42-9e1c-9b659f1d77fd"), new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null },
                    { new Guid("fcaa34b7-9ecd-4d57-b6e0-1ad233bfafb0"), "48.537.523/0001-01", new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2536), (byte)1, null, "Banco do Brasil", new Guid("99daffc0-d045-4a31-8151-5865227dd317"), new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_wallet",
                columns: new[] { "wal_Id", "bkr_id", "d_created", "enabled", "last_update", "wal_name", "usu_id", "user_created", "user_last_update" },
                values: new object[] { new Guid("846fde86-40f0-4ac0-994f-baf51ec85e3c"), new Guid("918282dc-5ce2-4d1d-bf76-2430229c4a1b"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2515), (byte)1, null, "Minha Carteira", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "tb_actives",
                columns: new[] { "act_id", "act_category", "cpy_id", "d_created", "enabled", "last_update", "act_price", "act_ticker", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("95526ac9-8450-453e-9e01-fd55d94cc81c"), 0, new Guid("fcaa34b7-9ecd-4d57-b6e0-1ad233bfafb0"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2559), (byte)1, null, 0m, "BBAS3", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null },
                    { new Guid("a3dfa9c7-f30c-4900-bf6b-3134a1fa674a"), 0, new Guid("c7e5f1dd-1348-4da5-a256-f2cd8df0ff94"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2557), (byte)1, null, 0m, "MGLU3", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null },
                    { new Guid("ada4a647-af12-46a6-bede-50a7040a4f1d"), 0, new Guid("a0b3920e-04f4-4254-9ae6-73a6d915c175"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2561), (byte)1, null, 0m, "TAEE3", new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_actives_company",
                columns: new[] { "aoc_id", "act_id", "aoc_amount", "bkr_id", "aoc_date_operation", "d_created", "enabled", "last_update", "aoc_operation", "aoc_unit_cost", "user_created", "usu_id", "user_last_update", "wal_Id" },
                values: new object[,]
                {
                    { new Guid("27959e32-c302-47db-a040-be422c9cc7f3"), new Guid("ada4a647-af12-46a6-bede-50a7040a4f1d"), 600m, new Guid("918282dc-5ce2-4d1d-bf76-2430229c4a1b"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2593), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2594), (byte)1, null, 0, 13.5m, new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null, new Guid("846fde86-40f0-4ac0-994f-baf51ec85e3c") },
                    { new Guid("623bedde-768a-49af-ae24-f240f80dbab3"), new Guid("a3dfa9c7-f30c-4900-bf6b-3134a1fa674a"), 50m, new Guid("918282dc-5ce2-4d1d-bf76-2430229c4a1b"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2580), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2580), (byte)1, null, 0, 22.5m, new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null, new Guid("846fde86-40f0-4ac0-994f-baf51ec85e3c") },
                    { new Guid("d60448e1-6072-4b68-8f4e-c8ce30e1eefc"), new Guid("95526ac9-8450-453e-9e01-fd55d94cc81c"), 200m, new Guid("918282dc-5ce2-4d1d-bf76-2430229c4a1b"), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2590), new DateTime(2023, 4, 23, 18, 0, 50, 425, DateTimeKind.Local).AddTicks(2590), (byte)1, null, 0, 43.5m, new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), new Guid("2ad284fe-82e4-4d37-a242-75e54ece0989"), null, new Guid("846fde86-40f0-4ac0-994f-baf51ec85e3c") }
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
