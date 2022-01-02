using EPIMS_API.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Context
{
    public class EPIMSContext : DbContext
    {
        /// <summary>
        /// 製品
        /// </summary>
        public DbSet<ProductData> ProductDatas { get; set; }
        /// <summary>
        /// 製品画像
        /// </summary>
        public DbSet<ProductImageData> ProductImageDatas { get; set; }
        /// <summary>
        /// 製品詳細
        /// </summary>
        public DbSet<ProductDetailData> ProductDetailDatas { get; set; }
        /// <summary>
        /// カテゴリー
        /// </summary>
        public DbSet<CategoryData> CategoryDatas { get; set; }


        public EPIMSContext(DbContextOptions<EPIMSContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryData>().ToTable("Category");
            builder.Entity<ProductData>().ToTable("Product");
            builder.Entity<ProductImageData>().ToTable("ProductImage")
                .HasOne(img => img.ProductData)
                .WithMany(p => p.ProductImageList)
                .HasForeignKey(img => img.ProductNo);
            builder.Entity<ProductDetailData>().ToTable("ProductDetail");
        }
    }
}
