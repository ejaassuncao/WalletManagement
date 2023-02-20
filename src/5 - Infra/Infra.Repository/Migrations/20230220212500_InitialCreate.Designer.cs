﻿// <auto-generated />
using System;
using Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Repository.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230220212500_InitialCreate")]
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

            modelBuilder.Entity("Infra.Repository.DataModel.Broker", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BkrCnpj")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("bkr_cnpj");

                    b.Property<string>("BkrNomefantasia")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("bkr_nomefantasia");

                    b.Property<string>("BkrRazaosocial")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("bkr_razaosocial");

                    b.Property<string>("CidUserCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CIdUserCreated");

                    b.Property<string>("CidUserLastUpdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CIdUserLastUpdate");

                    b.Property<DateTime>("Dcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("DCreated");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("bkr_id");

                    b.ToTable("Broker");
                });

            modelBuilder.Entity("Infra.Repository.DataModel.TbSector", b =>
                {
                    b.Property<Guid>("SctId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("sct_Id")
                        .HasComment("pk table");

                    b.Property<string>("CidUserCreated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CIdUserCreated");

                    b.Property<string>("CidUserLastUpdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CIdUserLastUpdate");

                    b.Property<byte>("Enabled")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SctDcreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("sct_DCreated");

                    b.Property<string>("SctName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("sct_name")
                        .HasComment("sector name");

                    b.HasKey("SctId")
                        .HasName("sct_id");

                    b.ToTable("tb_sector", null, t =>
                        {
                            t.HasComment("abbreviation: sct\r\nDescription: table sector");
                        });
                });

            modelBuilder.Entity("Infra.Repository.DataModel.TbWallet", b =>
                {
                    b.Property<Guid>("WalId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("wal_Id")
                        .HasComment("PK table");

                    b.Property<string>("WalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("wal_name")
                        .HasComment("Name wallet");

                    b.Property<string>("WalNew")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("wal_new");

                    b.HasKey("WalId")
                        .HasName("wal_Id");

                    b.ToTable("tb_wallet", null, t =>
                        {
                            t.HasComment("abbreviation:  wal\r\nDescription: tables wallet");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
