using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Data
{
    public class InventoryData
    {
        public InventoryData() { }

        /// <summary>
        /// 在庫番号
        /// </summary>
        [Key]
        public int InventoryNo { get; set; }

        /// <summary>
        /// 製品番号
        /// </summary>
        [NotNull]
        public int ProductNo { get; set; }

        /// <summary>
        /// 製品
        /// </summary>
        [ForeignKey("ProductNo")]
        [JsonIgnore]
        public ProductData ProductData { get; set; }

        /// <summary>
        /// 個数
        /// </summary>
        [NotNull]
        public int StockQuantity { get; set; }

        /// <summary>
        /// 入庫日
        /// </summary>
        [NotNull]
        public DateTime DeliveredDate { get; set; }

        /// <summary>
        /// 保管場所
        /// </summary>
        [NotNull]
        [MaxLength(200)]
        public string Location { get; set; }

        /// <summary>
        /// ステータスコード
        /// コードマスタID:IVNT
        /// </summary>
        [NotNull]
        [MaxLength(3)]
        public string StatusCode { get; set; }
    }
}
