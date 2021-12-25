using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Data
{
    /// <summary>
    /// 製品詳細
    /// </summary>
    public class ProductDetailData
    {
        public ProductDetailData()
        {
        }

        /// <summary>
        /// 製品
        /// </summary>
        public ProductData ProductData { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 個数名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CountName { get; set; }

        /// <summary>
        /// データシートファイルパス
        /// </summary>
        public string DataSheetPath { get; set; }

        /// <summary>
        /// 仕様
        /// </summary>
        public string SpecDesc { get; set; }

        /// <summary>
        /// 商品URL
        /// </summary>
        public string Url { get; set; }
    }
}
