using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
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
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
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
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
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
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_company", x => x.cpyid);
                    table.ForeignKey(
                        name: "FK_tb_company_tb_sector_SetorId",
                        column: x => x.SetorId,
                        principalTable: "tb_sector",
                        principalColumn: "sct_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "sufix: cpy");

            migrationBuilder.CreateTable(
                name: "tb_wallet",
                columns: table => new
                {
                    walId = table.Column<Guid>(name: "wal_Id", type: "uniqueidentifier", nullable: false),
                    walname = table.Column<string>(name: "wal_name", type: "nvarchar(120)", maxLength: 120, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrokerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_wallet", x => x.walId);
                    table.ForeignKey(
                        name: "FK_tb_wallet_tb_broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "tb_broker",
                        principalColumn: "bkr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_wallet_tb_user_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "tb_user",
                        principalColumn: "usu_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "sufix: wal");

            migrationBuilder.CreateTable(
                name: "tb_actives",
                columns: table => new
                {
                    actid = table.Column<Guid>(name: "act_id", type: "uniqueidentifier", nullable: false),
                    actticker = table.Column<string>(name: "act_ticker", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    actprice = table.Column<decimal>(name: "act_price", type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    acttypeactives = table.Column<int>(name: "act_typeactives", type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_actives", x => x.actid);
                    table.ForeignKey(
                        name: "FK_tb_actives_tb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tb_company",
                        principalColumn: "cpy_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "sufix: act");

            migrationBuilder.CreateTable(
                name: "tb_actives_company",
                columns: table => new
                {
                    aocid = table.Column<Guid>(name: "aoc_id", type: "uniqueidentifier", nullable: false),
                    aocamount = table.Column<int>(name: "aoc_amount", type: "int", nullable: false),
                    aocunitcost = table.Column<decimal>(name: "aoc_unit_cost", type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    aocdatebuy = table.Column<DateTime>(name: "aoc_date_buy", type: "datetime2", nullable: false),
                    aocoperation = table.Column<int>(name: "aoc_operation", type: "int", nullable: false),
                    ActiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrokerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TbWalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    dcreated = table.Column<DateTime>(name: "d_created", type: "datetime2", nullable: false),
                    usercreated = table.Column<int>(name: "user_created", type: "int", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "datetime2", nullable: true),
                    userlastupdate = table.Column<int>(name: "user_last_update", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_actives_company", x => x.aocid);
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_actives_ActiveId",
                        column: x => x.ActiveId,
                        principalTable: "tb_actives",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "tb_broker",
                        principalColumn: "bkr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "usu_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_actives_company_tb_wallet_TbWalletId",
                        column: x => x.TbWalletId,
                        principalTable: "tb_wallet",
                        principalColumn: "wal_Id");
                },
                comment: "sufix: aoc");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_CompanyId",
                table: "tb_actives",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_ActiveId",
                table: "tb_actives_company",
                column: "ActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_BrokerId",
                table: "tb_actives_company",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_TbWalletId",
                table: "tb_actives_company",
                column: "TbWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_actives_company_UserId",
                table: "tb_actives_company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_company_SetorId",
                table: "tb_company",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_wallet_BrokerId",
                table: "tb_wallet",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_wallet_OwnerId",
                table: "tb_wallet",
                column: "OwnerId");
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
