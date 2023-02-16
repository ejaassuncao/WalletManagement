using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Ef.Migrations
{
    /// <inheritdoc />
    public partial class CreateBroker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Sector_SectorId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Sector_SetorId",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sector",
                table: "Sector");

            migrationBuilder.RenameTable(
                name: "Sector",
                newName: "sector");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "sector",
                newName: "sct_name");

            migrationBuilder.AlterColumn<string>(
                name: "sct_name",
                table: "sector",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "sct_id",
                table: "sector",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bkrnomefantasia = table.Column<string>(name: "bkr_nomefantasia", type: "nvarchar(60)", maxLength: 60, nullable: true),
                    bkrrazaosocial = table.Column<string>(name: "bkr_razaosocial", type: "nvarchar(60)", maxLength: 60, nullable: true),
                    bkrcnpj = table.Column<string>(name: "bkr_cnpj", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIdUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIdUserLastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bkr_id", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Company_sector_SectorId",
                table: "Company",
                column: "SectorId",
                principalTable: "sector",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_sector_SetorId",
                table: "Company",
                column: "SetorId",
                principalTable: "sector",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_sector_SectorId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_sector_SetorId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropPrimaryKey(
                name: "sct_id",
                table: "sector");

            migrationBuilder.RenameTable(
                name: "sector",
                newName: "Sector");

            migrationBuilder.RenameColumn(
                name: "sct_name",
                table: "Sector",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sector",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sector",
                table: "Sector",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Sector_SectorId",
                table: "Company",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Sector_SetorId",
                table: "Company",
                column: "SetorId",
                principalTable: "Sector",
                principalColumn: "Id");
        }
    }
}
