﻿// <auto-generated />
using System;
using Infra.Ef.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Ef.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230616191401_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infra.Ef.DataModel.TbActive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("act_id");

                    b.Property<int>("Category")
                        .HasColumnType("int")
                        .HasColumnName("act_category");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cpy_id");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("act_price");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("act_ticker")
                        .HasComment("Name Ticker");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("tb_actives", t =>
                        {
                            t.HasComment("sufix: act");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("1b0f4b1f-828c-4936-ab72-1122b3f5d7ab"),
                            Category = 0,
                            CompanyId = new Guid("fd4b5d91-8ad0-4323-96fe-8c1573a42b99"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7925),
                            Enabled = (byte)1,
                            Price = 0m,
                            Ticker = "MGLU3",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        },
                        new
                        {
                            Id = new Guid("433853d2-c779-42a0-86c7-5022394ec58b"),
                            Category = 0,
                            CompanyId = new Guid("f12f8f13-bec9-4774-b9f2-6bcbbcd65039"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7928),
                            Enabled = (byte)1,
                            Price = 0m,
                            Ticker = "BBAS3",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        },
                        new
                        {
                            Id = new Guid("d2aaeddb-aad5-402b-8cba-c1b5f87d41bf"),
                            Category = 0,
                            CompanyId = new Guid("180f672b-bf89-45a7-b31e-c6ed926679e2"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7930),
                            Enabled = (byte)1,
                            Price = 0m,
                            Ticker = "TAEE3",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbActivesOfCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("aoc_id");

                    b.Property<Guid?>("ActiveId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("act_id");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("aoc_amount");

                    b.Property<Guid?>("BrokerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bkr_id");

                    b.Property<DateTime>("DateOperation")
                        .HasColumnType("datetime2")
                        .HasColumnName("aoc_date_operation");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<int>("Operation")
                        .HasColumnType("int")
                        .HasColumnName("aoc_operation");

                    b.Property<decimal>("UnitCost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("aoc_unit_cost");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usu_id");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.Property<Guid?>("WalletId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("wal_Id");

                    b.HasKey("Id");

                    b.HasIndex("ActiveId");

                    b.HasIndex("BrokerId");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletId");

                    b.ToTable("tb_actives_company", t =>
                        {
                            t.HasComment("sufix: aoc");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("87eb1def-1515-4020-9081-5f17b6475cdd"),
                            ActiveId = new Guid("1b0f4b1f-828c-4936-ab72-1122b3f5d7ab"),
                            Amount = 50m,
                            BrokerId = new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"),
                            DateOperation = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7945),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7946),
                            Enabled = (byte)1,
                            Operation = 0,
                            UnitCost = 22.5m,
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            UserId = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            WalletId = new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da")
                        },
                        new
                        {
                            Id = new Guid("15e159dd-990c-4f0a-ac5d-21e3975a609d"),
                            ActiveId = new Guid("433853d2-c779-42a0-86c7-5022394ec58b"),
                            Amount = 200m,
                            BrokerId = new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"),
                            DateOperation = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7953),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7953),
                            Enabled = (byte)1,
                            Operation = 0,
                            UnitCost = 43.5m,
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            UserId = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            WalletId = new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da")
                        },
                        new
                        {
                            Id = new Guid("08a346ca-4f7c-4c75-8563-2573cdf55608"),
                            ActiveId = new Guid("d2aaeddb-aad5-402b-8cba-c1b5f87d41bf"),
                            Amount = 600m,
                            BrokerId = new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"),
                            DateOperation = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7956),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7956),
                            Enabled = (byte)1,
                            Operation = 0,
                            UnitCost = 13.5m,
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            UserId = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            WalletId = new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbBroker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bkr_id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("bkr_cnpj");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("bkr_corporate_name");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("bkr_fantasy_name");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.ToTable("tb_broker", t =>
                        {
                            t.HasComment("sufix: bkr");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"),
                            CNPJ = "48.537.525/0001-01",
                            CorporateName = "Itau",
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7866),
                            Enabled = (byte)1,
                            FantasyName = "Itau investimentos",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cpy_id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("cpy_cnpj");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("cpy_name");

                    b.Property<Guid?>("SetorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("sct_id");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("tb_company", t =>
                        {
                            t.HasComment("sufix: cpy");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("fd4b5d91-8ad0-4323-96fe-8c1573a42b99"),
                            CNPJ = "48.537.555/0001-01",
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7903),
                            Enabled = (byte)1,
                            Name = "Magazine Luiza",
                            SetorId = new Guid("7c3c1968-a503-4c03-b8ee-9526bc2a339b"),
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        },
                        new
                        {
                            Id = new Guid("f12f8f13-bec9-4774-b9f2-6bcbbcd65039"),
                            CNPJ = "48.537.523/0001-01",
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7906),
                            Enabled = (byte)1,
                            Name = "Banco do Brasil",
                            SetorId = new Guid("6ef7a2cf-9157-48ee-8fa9-e8a5a99f2946"),
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        },
                        new
                        {
                            Id = new Guid("180f672b-bf89-45a7-b31e-c6ed926679e2"),
                            CNPJ = "48.566.523/0001-01",
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7907),
                            Enabled = (byte)1,
                            Name = "Taeesa transmissão Eletrica",
                            SetorId = new Guid("42f99c91-c3a6-4e59-8473-5d443bcb58ce"),
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbSector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("sct_id");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("sct_name");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.ToTable("tb_sector", t =>
                        {
                            t.HasComment("sufix: sct");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("7c3c1968-a503-4c03-b8ee-9526bc2a339b"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7839),
                            Enabled = (byte)1,
                            Name = "Varejo",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        },
                        new
                        {
                            Id = new Guid("6ef7a2cf-9157-48ee-8fa9-e8a5a99f2946"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7842),
                            Enabled = (byte)1,
                            Name = "Financeiro",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        },
                        new
                        {
                            Id = new Guid("42f99c91-c3a6-4e59-8473-5d443bcb58ce"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7843),
                            Enabled = (byte)1,
                            Name = "Eletrico",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usu_id");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("usu_login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("usu_password");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.ToTable("tb_user", t =>
                        {
                            t.HasComment("sufix: usu");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7528),
                            Enabled = (byte)1,
                            Login = "elton",
                            Password = "123456",
                            UserCreated = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("wal_Id");

                    b.Property<Guid?>("BrokerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bkr_id");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("wal_name");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usu_id");

                    b.Property<Guid>("UserCreated")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_created");

                    b.Property<Guid?>("UserLastUpdate")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("tb_wallet", t =>
                        {
                            t.HasComment("sufix: wal");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("1dc38a0e-b977-43cc-a4b2-59303bf432da"),
                            BrokerId = new Guid("3f936455-e4cb-4887-8a4c-f2f6389f9837"),
                            Dcreated = new DateTime(2023, 6, 16, 16, 14, 1, 678, DateTimeKind.Local).AddTicks(7883),
                            Enabled = (byte)1,
                            Name = "Minha Carteira",
                            OwnerId = new Guid("4dd0c335-6a75-49fd-b2ad-e0b6ddbb2435"),
                            UserCreated = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbActive", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbCompany", "Company")
                        .WithMany("Actives")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbActivesOfCompany", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbActive", "Active")
                        .WithMany()
                        .HasForeignKey("ActiveId");

                    b.HasOne("Infra.Ef.DataModel.TbBroker", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId");

                    b.HasOne("Infra.Ef.DataModel.TbUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Infra.Ef.DataModel.TbWallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId");

                    b.Navigation("Active");

                    b.Navigation("Broker");

                    b.Navigation("User");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbCompany", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbSector", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbWallet", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbBroker", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId");

                    b.HasOne("Infra.Ef.DataModel.TbUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Broker");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbCompany", b =>
                {
                    b.Navigation("Actives");
                });
#pragma warning restore 612, 618
        }
    }
}