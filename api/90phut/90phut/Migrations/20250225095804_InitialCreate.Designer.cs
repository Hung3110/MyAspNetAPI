﻿// <auto-generated />
using GoodsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodsAPI.Migrations
{
    [DbContext(typeof(GoodsDbContext))]
    [Migration("20250225095804_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoodsAPI.Models.HangHoa", b =>
                {
                    b.Property<string>("MaHangHoa")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenHangHoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHangHoa");

                    b.ToTable("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
