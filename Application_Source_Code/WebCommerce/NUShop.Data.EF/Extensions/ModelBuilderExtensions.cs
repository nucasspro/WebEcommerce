﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NUShop.Data.EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, DbEntityConfiguration<T> entityConfiguration) where T : class
        {
            modelBuilder.Entity<T>(entityConfiguration.Configure);
        }
    }

    public abstract class DbEntityConfiguration<T> where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> entity);
    }
}