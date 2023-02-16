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
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIdUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIdUserLastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cnyname = table.Column<string>(name: "cny_name", type: "nvarchar(60)", maxLength: 60, nullable: true),
                    cnycnpj = table.Column<string>(name: "cny_cnpj", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIdUserCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIdUserLastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cny_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Sector_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Sector",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_SectorId",
                table: "Company",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_SetorId",
                table: "Company",
                column: "SetorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
