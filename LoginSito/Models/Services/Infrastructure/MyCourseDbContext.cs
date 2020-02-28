﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LoginSito.Models.Entities;

namespace LoginSito.Models.Services.Infrastructure
{
    public partial class MyCourseDbContext : DbContext
    {
        public MyCourseDbContext()
        {
        }

        public MyCourseDbContext(DbContextOptions<MyCourseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apples> Apples { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=superdatabaseditest.database.windows.net;Database=Superdatabase;User Id=SuperUser;Password=MarcoGraziottiRegna33;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apples>(entity =>
            {
                entity.Property(e => e.Color).HasColumnType("text");

                entity.Property(e => e.Origin).HasColumnType("text");

                entity.Property(e => e.Variety).HasColumnType("text");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CurrentPriceAmount)
                    .HasColumnName("CurrentPrice_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.CurrentPriceCurrency)
                    .IsRequired()
                    .HasColumnName("CurrentPrice_Currency")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('EUR')");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.FullPriceAmount)
                    .HasColumnName("FullPrice_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.FullPriceCurrency)
                    .IsRequired()
                    .HasColumnName("FullPrice_Currency")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('EUR')");

                entity.Property(e => e.ImagePath).HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('00:00:00')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Lessons__CourseI__5070F446");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
