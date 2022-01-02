using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Data
{
    public class ProductImageData
    {
        /// <summary>
        /// 画像番号
        /// </summary>
        [Key]
        public int ImageNo { get; set; }

        /// <summary>
        /// 製品番号
        /// </summary>
        public int ProductNo { get; set; }

        /// <summary>
        /// 製品情報
        /// </summary>
        [ForeignKey("ProductNo")]
        [JsonIgnore]
        public virtual ProductData ProductData { get; set; }

        /// <summary>
        /// 画像パス
        /// </summary>
        [Required]
        public string ImagePath { get; set; }
    }
}
