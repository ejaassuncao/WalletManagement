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
    [Migration("20230421190728_InitialCreate")]
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

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
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
                        .HasColumnName("act_ticker");

                    b.Property<int>("TypeActives")
                        .HasColumnType("int")
                        .HasColumnName("act_typeactives");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("tb_actives", t =>
                        {
                            t.HasComment("sufix: act");
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbActivesOfCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("aoc_id");

                    b.Property<Guid>("ActiveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("aoc_amount");

                    b.Property<Guid>("BrokerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateBuy")
                        .HasColumnType("datetime2")
                        .HasColumnName("aoc_date_buy");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<int>("Operation")
                        .HasColumnType("int")
                        .HasColumnName("aoc_operation");

                    b.Property<Guid?>("TbWalletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("UnitCost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("aoc_unit_cost");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("ActiveId");

                    b.HasIndex("BrokerId");

                    b.HasIndex("TbWalletId");

                    b.HasIndex("UserId");

                    b.ToTable("tb_actives_company", t =>
                        {
                            t.HasComment("sufix: aoc");
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

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasColumnName("enabled");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("bkr_fantasy_name");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.ToTable("tb_broker", t =>
                        {
                            t.HasComment("sufix: bkr");
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

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("cpy_name");

                    b.Property<Guid>("SetorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("tb_company", t =>
                        {
                            t.HasComment("sufix: cpy");
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

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("sct_name");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.ToTable("tb_sector", t =>
                        {
                            t.HasComment("sufix: sct");
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

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
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

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.ToTable("tb_user", t =>
                        {
                            t.HasComment("sufix: usu");
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("wal_Id");

                    b.Property<Guid>("BrokerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_created");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasColumnName("enabled");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_update");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("wal_name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int")
                        .HasColumnName("user_created");

                    b.Property<int?>("UserLastUpdate")
                        .HasColumnType("int")
                        .HasColumnName("user_last_update");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("tb_wallet", t =>
                        {
                            t.HasComment("sufix: wal");
                        });
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbActive", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbCompany", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbActivesOfCompany", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbActive", "Active")
                        .WithMany()
                        .HasForeignKey("ActiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Ef.DataModel.TbBroker", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Ef.DataModel.TbWallet", null)
                        .WithMany("Actives")
                        .HasForeignKey("TbWalletId");

                    b.HasOne("Infra.Ef.DataModel.TbUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Active");

                    b.Navigation("Broker");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbCompany", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbSector", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbWallet", b =>
                {
                    b.HasOne("Infra.Ef.DataModel.TbBroker", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.Ef.DataModel.TbUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Broker");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Infra.Ef.DataModel.TbWallet", b =>
                {
                    b.Navigation("Actives");
                });
#pragma warning restore 612, 618
        }
    }
}
