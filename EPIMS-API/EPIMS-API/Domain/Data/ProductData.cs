using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Data
{
    /// <summary>
    /// 製品
    /// </summary>
    public class ProductData
    {

        /// <summary>
        /// 製品番号
        /// </summary>
        [Key]
        [NotNull]
        public int ProductNo { get; set; }

        /// <summary>
        /// 製品名
        /// </summary>
        [NotNull]
        [MaxLength(200)]
        public string ProductName { get; set; }

        /// <summary>
        /// 型番
        /// </summary>
        [NotNull]
        [MaxLength(50)]
        public string ModelName { get; set; }

        /// <summary>
        /// 通販コード
        /// </summary>
        [MaxLength(50)]
        public string ShopCode { get; set; }

        /// <summary>
        /// メーカー
        /// </summary>
        [MaxLength(50)]
        public string Maker { get; set; }

        /// <summary>
        /// カテゴリ番号
        /// </summary>
        public int CategoryNo { get; set; }

        /// <summary>
        /// カテゴリー
        /// </summary> 
        [ForeignKey("CategoryNo")]
        public CategoryData CategoryData { get; set; }

        /// <summary>
        /// 画像パスリスト
        /// </summary>
        public List<ProductImageData> ProductImageList { get; set; }

    }
}
