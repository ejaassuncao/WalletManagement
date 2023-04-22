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
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                    aocamount = table.Column<int>(name: "aoc_amount", type: "int", nullable: false),
                    aocunitcost = table.Column<decimal>(name: "aoc_unit_cost", type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    aocdateoperation = table.Column<DateTime>(name: "aoc_date_operation", type: "datetime2", nullable: false),
                    aocoperation = table.Column<int>(name: "aoc_operation", type: "int", nullable: false),
                    usuid = table.Column<Guid>(name: "usu_id", type: "uniqueidentifier", nullable: true),
                    bkrid = table.Column<Guid>(name: "bkr_id", type: "uniqueidentifier", nullable: true),
                    walId = table.Column<Guid>(name: "wal_Id", type: "uniqueidentifier", nullable: true),
                    actid = table.Column<Guid>(name: "act_id", type: "uniqueidentifier", nullable: true),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
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
                values: new object[] { new Guid("d626b523-925e-450c-9b9a-2fa5d9cb4609"), "48.537.525/0001-01", "Itau", new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(4957), true, "Itau investimentos", null, new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null });

            migrationBuilder.InsertData(
                table: "tb_sector",
                columns: new[] { "sct_id", "d_created", "enabled", "last_update", "sct_name", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("2f4f26f3-edc1-4d0b-98eb-954bba05867a"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(4921), true, null, "Financeiro", new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null },
                    { new Guid("e07d8a92-dede-43ec-ad4b-e5e8c584b485"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(4918), true, null, "Varejo", new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_user",
                columns: new[] { "usu_id", "d_created", "enabled", "last_update", "usu_login", "usu_password", "user_created", "user_last_update" },
                values: new object[] { new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(4663), true, null, "elton", "123456", new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null });

            migrationBuilder.InsertData(
                table: "tb_company",
                columns: new[] { "cpy_id", "cpy_cnpj", "d_created", "enabled", "last_update", "cpy_name", "sct_id", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("263952b2-7f75-42b1-ae67-2088b688e4f9"), "48.537.555/0001-01", new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5599), true, null, "Magazine Luiza", new Guid("e07d8a92-dede-43ec-ad4b-e5e8c584b485"), new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null },
                    { new Guid("9d5a9448-b85a-4dc0-b711-1ba7cf6dc90c"), "48.537.523/0001-01", new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5609), true, null, "Banco do Brasil", new Guid("2f4f26f3-edc1-4d0b-98eb-954bba05867a"), new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_wallet",
                columns: new[] { "wal_Id", "bkr_id", "d_created", "enabled", "last_update", "wal_name", "usu_id", "user_created", "user_last_update" },
                values: new object[] { new Guid("9f616cff-2bc5-4349-b179-3767fa4567d3"), new Guid("d626b523-925e-450c-9b9a-2fa5d9cb4609"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(4974), true, null, "Minha Carteira", new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "tb_actives",
                columns: new[] { "act_id", "act_category", "cpy_id", "d_created", "enabled", "last_update", "act_price", "act_ticker", "user_created", "user_last_update" },
                values: new object[,]
                {
                    { new Guid("6bb239aa-288c-4c88-be49-44db2e50436e"), 0, new Guid("263952b2-7f75-42b1-ae67-2088b688e4f9"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5648), true, null, 10.8m, "MGLU3", new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null },
                    { new Guid("861f4f24-c553-40ba-beb0-4179fcb8abc1"), 0, new Guid("9d5a9448-b85a-4dc0-b711-1ba7cf6dc90c"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5652), true, null, 40.7m, "BBAS3", new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null }
                });

            migrationBuilder.InsertData(
                table: "tb_actives_company",
                columns: new[] { "aoc_id", "act_id", "aoc_amount", "bkr_id", "aoc_date_operation", "d_created", "enabled", "last_update", "aoc_operation", "aoc_unit_cost", "user_created", "usu_id", "user_last_update", "wal_Id" },
                values: new object[,]
                {
                    { new Guid("390901e8-d086-4430-9762-a35c9a011144"), new Guid("6bb239aa-288c-4c88-be49-44db2e50436e"), 50, new Guid("d626b523-925e-450c-9b9a-2fa5d9cb4609"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5678), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5678), true, null, 1, 22.5m, new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null, new Guid("9f616cff-2bc5-4349-b179-3767fa4567d3") },
                    { new Guid("64d1876b-7124-413e-a164-df628ea87c3f"), new Guid("861f4f24-c553-40ba-beb0-4179fcb8abc1"), 200, new Guid("d626b523-925e-450c-9b9a-2fa5d9cb4609"), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5684), new DateTime(2023, 4, 21, 22, 10, 9, 253, DateTimeKind.Local).AddTicks(5685), true, null, 1, 43.5m, new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), new Guid("59380a1e-b482-41ef-b81e-713042de4dea"), null, new Guid("9f616cff-2bc5-4349-b179-3767fa4567d3") }
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
