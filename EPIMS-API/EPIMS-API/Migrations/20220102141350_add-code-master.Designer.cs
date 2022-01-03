﻿// <auto-generated />
using EPIMS_API.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EPIMS_API.Migrations
{
    [DbContext(typeof(EPIMSContext))]
    [Migration("20220102141350_add-code-master")]
    partial class addcodemaster
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EPIMS_API.Domain.Data.CategoryData", b =>
                {
                    b.Property<int>("CategoryNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("CategoryNo");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.CodeMasterData", b =>
                {
                    b.Property<int>("CodeMasterNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("CodeName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Desc")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ID")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.HasKey("CodeMasterNo");

                    b.ToTable("CodeMaster");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductData", b =>
                {
                    b.Property<int>("ProductNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryNo")
                        .HasColumnType("integer");

                    b.Property<string>("Maker")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ShopCode")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ProductNo");

                    b.HasIndex("CategoryNo");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductDetailData", b =>
                {
                    b.Property<int>("ProductDetailNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CountName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("DataSheetPath")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("ProductNo")
                        .HasColumnType("integer");

                    b.Property<string>("SpecDesc")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("ProductDetailNo");

                    b.HasIndex("ProductNo");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductImageData", b =>
                {
                    b.Property<int>("ImageNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductNo")
                        .HasColumnType("integer");

                    b.HasKey("ImageNo");

                    b.HasIndex("ProductNo");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductData", b =>
                {
                    b.HasOne("EPIMS_API.Domain.Data.CategoryData", "CategoryData")
                        .WithMany()
                        .HasForeignKey("CategoryNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryData");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductDetailData", b =>
                {
                    b.HasOne("EPIMS_API.Domain.Data.ProductData", "ProductData")
                        .WithMany()
                        .HasForeignKey("ProductNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductData");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductImageData", b =>
                {
                    b.HasOne("EPIMS_API.Domain.Data.ProductData", "ProductData")
                        .WithMany("ProductImageList")
                        .HasForeignKey("ProductNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductData");
                });

            modelBuilder.Entity("EPIMS_API.Domain.Data.ProductData", b =>
                {
                    b.Navigation("ProductImageList");
                });
#pragma warning restore 612, 618
        }
    }
}
