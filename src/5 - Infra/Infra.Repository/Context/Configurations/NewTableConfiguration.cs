﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Infra.Repository.Context;
using Infra.Repository.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Infra.Repository.Context.Configurations
{
    public partial class NewTableConfiguration : IEntityTypeConfiguration<NewTable>
    {
        public void Configure(EntityTypeBuilder<NewTable> entity)
        {
            entity.HasKey(e => e.Id).HasName("NewTable_PK");

            entity.Property(e => e.Id).ValueGeneratedNever();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<NewTable> entity);
    }
}
