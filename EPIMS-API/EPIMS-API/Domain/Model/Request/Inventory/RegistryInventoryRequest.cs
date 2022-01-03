using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Request.Inventory
{
    /// <summary>
    /// 在庫管理登録リクエスト
    /// </summary>
    public class RegistryInventoryRequest
    {
        /// <summary>
        /// 製品番号
        /// </summary>
        [Required]
        public int ProductNo { get; set; }

        /// <summary>
        /// 個数
        /// </summary>
        [Required]
        [Min(0)]
        public int StockQuantity { get; set; }

        /// <summary>
        /// 入庫日
        /// </summary>
        [Required]
        public DateTime DeliveredDate { get; set; }

        /// <summary>
        /// 保管場所
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Location { get; set; }

        /// <summary>
        /// ステータスコード
        /// コードマスタID:IVNT
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string StatusCode { get; set; }
    }
}
